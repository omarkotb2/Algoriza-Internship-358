using DomainLayer.DTO.AdminDTO.PatientDTO;
using DomainLayer.Models;
using RepositoryLayer.Repository.AdminRepository.PatientRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AdminService.PatientService
{
    public class AdminPatientService : IAdminPatientService
    {
        private readonly IAdminPatientRepository _adminPatientRepository;
        public AdminPatientService(IAdminPatientRepository adminPatientRepository)
        {
            _adminPatientRepository = adminPatientRepository;
        }


        public List<GetAllPatientDTO> GetPatientDetails(int page, int pageSize, string search)
        {
            var Patients = _adminPatientRepository.GetPatientDetails(page,pageSize,search);
            return Patients;
        }

        public GetPatinetByIdDTO GetPatientById(int id)
        {
            var PatientFromDB = _adminPatientRepository.GetPatientById(id);
            if (PatientFromDB != null)
            {
               
                GetPatinetByIdDTO PatientDTO = new GetPatinetByIdDTO();

                PatientDTO.Iamge = PatientFromDB.User.Image;

                PatientDTO.FullName = PatientFromDB.User.FirstName +  " " + PatientFromDB.User.LastName;

                PatientDTO.Email = PatientFromDB.User.Email;

                PatientDTO.PhoneNumber = PatientFromDB.User.PhoneNumber;

                PatientDTO.Gender = PatientFromDB.User.Gender.Name;

                PatientDTO.DateOfBirth = PatientFromDB.User.DateOfBirth;

                PatientDTO.DoctorName = PatientFromDB.DoctorDetails.User.FirstName + " "  +PatientFromDB.DoctorDetails.User.LastName
                    ;
                PatientDTO.DoctorSpecialize = PatientFromDB.DoctorDetails.Specialization.Name;

                PatientDTO.Day = PatientFromDB.Appointment.Days.Name;

                PatientDTO.Price = PatientFromDB.DoctorDetails.Price;

                PatientDTO.DiscoundCode = PatientFromDB.Coupon.DiscoundCode;

                PatientDTO.FinalPrice = PatientFromDB.FinalPrice;

                PatientDTO.RequestStatus = PatientFromDB.RequestStatus.Name;


                return PatientDTO;


            }
            else
            {
                return null;
            }
           
        }


    }
}
