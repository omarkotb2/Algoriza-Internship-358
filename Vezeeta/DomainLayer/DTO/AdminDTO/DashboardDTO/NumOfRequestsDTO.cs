using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.AdminDTO.DashboardDTO
{
    public class NumOfRequestsDTO
    {
        public int TotalRequsts { get; set; }
        public int PendingReuests { get; set; }
        public int CompletedReuests { get; set; }
        public int CancelledReuests { get; set; }


    }
}
