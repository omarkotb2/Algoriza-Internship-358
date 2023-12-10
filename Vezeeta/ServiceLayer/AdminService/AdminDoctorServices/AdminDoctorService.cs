using DomainLayer.DTO.AdminDTO.DoctorDTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Repository.AdminRepository.DoctorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AdminService.DoctorServices
{
    public class AdminDoctorService : IAdminDoctorService
    {
        private readonly IAdminDoctorRepository _adminDoctorRepository;



        public AdminDoctorService(IAdminDoctorRepository adminDoctorRepository)
        {
            _adminDoctorRepository = adminDoctorRepository;
        }


        //------- Start (See his statistics) ----------//
        public int NumOfDoctors(int page, int pageSize, string search)
        {
            return _adminDoctorRepository.GetDoctorDetails(page,pageSize,search).Count;
        }

        //------- End (See his statistics) ----------//




        //----- Start (Get info about all doctors) --------//

        public List<AllDoctorDetailsDTO> GetDoctorDetails(int page, int pageSize, string search)
        {
            var docs = _adminDoctorRepository.GetDoctorDetails(page , pageSize , search);
            return docs;

        }
        public GetDoctorByIdDTO GetDoctorById(int id)
        {
            DoctorDetails Doc = _adminDoctorRepository.GetDoctorById(id);

            if (Doc != null && Doc.User.RoleId==2)
            {
                GetDoctorByIdDTO DoctorDetailsDTO = new GetDoctorByIdDTO();

                DoctorDetailsDTO.image=Doc.User.Image;
                DoctorDetailsDTO.FullName = Doc.User.FirstName + " " + Doc.User.LastName; 
                DoctorDetailsDTO.Email = Doc.User.Email;
                DoctorDetailsDTO.PhoneNumber = Doc.User.PhoneNumber;
                DoctorDetailsDTO.Specialize = Doc.Specialization.Name;
                DoctorDetailsDTO.Gender = Doc.User.Gender.Name;
                DoctorDetailsDTO.DateOfBirth = Doc.User.DateOfBirth;


                return DoctorDetailsDTO;
            }
            else return null;



        }


        public bool CreateDoctor(CreateNewDoctorDTO NewModel)
        {

            DoctorDetails Doc = new DoctorDetails();
            ApplicationUser User = new ApplicationUser();


            if (NewModel != null)
            {
                User.FirstName = NewModel.FirstName;
                User.LastName = NewModel.LastName;
                User.Email = NewModel.Email;
                User.PhoneNumber = NewModel.PhoneNumber;
                Doc.SpecializationId = NewModel.SpecializeId;
                User.Genderid = NewModel.GenderId;
                User.DateOfBirth = DateTime.Parse(NewModel.DateOfBirth);
                User.RoleId = 2;
                Doc.User = User;

                _adminDoctorRepository.CreateDoctor(Doc);
                return true;
            }
            else { return false; }

        }

        public bool UpdateDoctor(UpdateDoctorDTO NewModel, int id)
        {
            DoctorDetails DocInDB = _adminDoctorRepository.GetDoctorById(id);

            if (DocInDB != null)
            {

                DocInDB.User.FirstName = NewModel.FirstName;
                DocInDB.User.LastName = NewModel.LastName;
                DocInDB.User.Email = NewModel.Email;
                DocInDB.User.PhoneNumber = NewModel.PhoneNumber;
                DocInDB.User.Genderid = NewModel.GenderID;
                DocInDB.User.DateOfBirth = DateTime.Parse(NewModel.DateOfBirth);
                DocInDB.SpecializationId = NewModel.SpecializeID;

                _adminDoctorRepository.UpdateDoctor(DocInDB);

                return true;
            }
            else return false;

        }
        public bool DeleteDoctor(int id)
        {
            DoctorDetails OldDoc = _adminDoctorRepository.GetDoctorById(id);
            Booking booking = new Booking();
            if (OldDoc != null && booking.DoctorDetails == null)
            {
                _adminDoctorRepository.DeleteDoctor(OldDoc);
                return true;
            }
            else
            {
                return false;
            } 

        }

        //----- End (Get info about all doctors) --------//

    }

}
