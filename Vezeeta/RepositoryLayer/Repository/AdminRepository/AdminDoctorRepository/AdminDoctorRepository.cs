using DomainLayer.DTO.AdminDTO.DoctorDTO;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.AdminRepository.DoctorRepository
{
    public class AdminDoctorRepository : IAdminDoctorRepository
    {
        private readonly ApplicationDbContext _Context;

        public AdminDoctorRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        //----- Start (Get info about all doctors) --------//

        public List<AllDoctorDetailsDTO> GetDoctorDetails(int page, int pageSize, string search)
        {


            var Doc = _Context.DoctorDetails
                                    .Include(d => d.User)
                                    .ThenInclude(g => g.Gender)
                                    .Include(d => d.Specialization)
                                    .Where(d=> d.User.FirstName.Equals(search))
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .Select(Doc => new AllDoctorDetailsDTO
                                    {
                                        Iamge = Doc.User.Image,
                                        FullName = Doc.User.FirstName + " " + Doc.User.LastName,
                                        Email = Doc.User.Email,
                                        PhoneNumber = Doc.User.PhoneNumber,
                                        Gender = Doc.User.Gender.Name,
                                        Specialize = Doc.Specialization.Name
                                    })
                                   
                                    .ToList();

            return Doc;
        }
        public DoctorDetails GetDoctorById(int id)
        {

            var Doc = _Context.DoctorDetails
                         .Include(doc => doc.User)
                         .ThenInclude(gen => gen.Gender)
                         .Include(spec => spec.Specialization)
                         .FirstOrDefault(doc => doc.User.Id == id);
            return Doc;

        }
        public DoctorDetails CreateDoctor(DoctorDetails Doc)
        {

            _Context.Add(Doc);
            _Context.SaveChanges();
            return Doc;


        }
        public DoctorDetails UpdateDoctor(DoctorDetails UpdatedModel)
        {

            _Context.Update(UpdatedModel);
            _Context.SaveChanges();
            return UpdatedModel;

        }
        public void DeleteDoctor(DoctorDetails DocModel)
        {
            _Context.DoctorDetails.Remove(DocModel);
            _Context.SaveChanges();

        }

        //----- End (Get info about all doctors) --------//


    }
}
