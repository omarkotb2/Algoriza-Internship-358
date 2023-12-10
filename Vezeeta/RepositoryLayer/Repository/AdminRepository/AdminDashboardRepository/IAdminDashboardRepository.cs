using DomainLayer.DTO.AdminDTO.DoctorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using DomainLayer.DTO.AdminDTO.DashboardDTO;

namespace RepositoryLayer.Repository.AdminRepository.DashboardRepository
{
    public interface IAdminDashboardRepository
    {
        int NumOfAllRequests();
        int NumOfPendingRequest();
        int NumOfCompletedRequestst();
        int NumOfCancelledRequest();

       // List<TopFiveSpecializationsDTO> TopFiveSpecializations();

    }
}
