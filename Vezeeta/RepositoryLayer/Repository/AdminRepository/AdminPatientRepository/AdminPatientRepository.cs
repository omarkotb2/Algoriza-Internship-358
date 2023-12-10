using DomainLayer.DTO.AdminDTO.PatientDTO;
using DomainLayer.DTO.AdminDTO.DoctorDTO;
using DomainLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.AdminRepository.PatientRepository
{
    public class AdminPatientRepository : IAdminPatientRepository
    {

        private readonly ApplicationDbContext _Context;
        public AdminPatientRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public Booking GetPatientById(int id)
        {
            var BookingModel = _Context.Bookings
                                .Include(patient => patient.User).ThenInclude(gen => gen.Gender)
                                .Include(Doc => Doc.DoctorDetails).ThenInclude(D => D.User)
                                .Include(Doc=>Doc.DoctorDetails).ThenInclude(D=>D.Specialization)
                                .Include(Appointment => Appointment.Appointment).ThenInclude(d => d.Days)
                                .Include(Cop => Cop.Coupon).ThenInclude(Disc => Disc.DiscountType)
                                .Include(Status=>Status.RequestStatus)
                                .FirstOrDefault(patient => patient.User.RoleId == 3);


            return BookingModel;


        }



        public List<GetAllPatientDTO> GetPatientDetails(int page, int pageSize, string search)
        {
            var Patients = _Context.ApplicationUsers
                .Include(role => role.Role)
                .Include(G => G.Gender)
                .Where(d => d.FirstName.Equals(search))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)        
                .Where(role => role.RoleId == 3)
                .Select(patient => new GetAllPatientDTO
                {
                   Iamge = patient.Image,
                   FullName = patient.FirstName + " " + patient.LastName,
                   Email = patient.Email,
                   PhoneNumber = patient.PhoneNumber,
                   Gender = patient.Gender.Name,
                   DateOfBirth = patient.DateOfBirth.ToString(),


                }) ;

            return Patients.ToList();
        }


    }
}
