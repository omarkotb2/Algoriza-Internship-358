using DomainLayer.DTO.AdminDTO.DoctorDTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.AdminRepository.DoctorRepository
{
    public interface IAdminDoctorRepository
    {

        //----- Start (Get info about all doctors) --------//

        List<AllDoctorDetailsDTO> GetDoctorDetails(int page, int pageSize, string search);
        DoctorDetails GetDoctorById(int id);
        DoctorDetails CreateDoctor(DoctorDetails NewModel);
        DoctorDetails UpdateDoctor(DoctorDetails UpdatedModel);
        void DeleteDoctor(DoctorDetails DocModel);

        //----- End (Get info about all doctors) --------//




    }
}
