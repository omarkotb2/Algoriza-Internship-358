using DomainLayer.DTO.AdminDTO.PatientDTO;
using DomainLayer.DTO.AdminDTO.DoctorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace ServiceLayer.AdminService.PatientService
{
    public interface IAdminPatientService
    {

        List<GetAllPatientDTO> GetPatientDetails(int page, int pageSize, string search);
        GetPatinetByIdDTO GetPatientById(int id);

    }
}
