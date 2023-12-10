using DomainLayer.DTO.AdminDTO.DashboardDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AdminService.DashboardService
{
    public interface IAdminDashboardService
    {
        int NumOfDoctors(int page, int pageSize, string search);
        int NumOfPatients(int page, int pageSize, string search);
        NumOfRequestsDTO NumOfRequests();
        //List<TopFiveSpecializationsDTO> TopFiveSpecializations();

    }
}
