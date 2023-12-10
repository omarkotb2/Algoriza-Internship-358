using DomainLayer.DTO.AdminDTO.DashboardDTO;
using DomainLayer.DTO.AdminDTO.DoctorDTO;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository.AdminRepository.DoctorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.AdminRepository.DashboardRepository
{
    public class AdminDashboardRepository : IAdminDashboardRepository
    {
        private readonly ApplicationDbContext _Context;


        public AdminDashboardRepository(ApplicationDbContext Context)
        {
            _Context = Context;

        }

        public int NumOfAllRequests()
        {
            var AllRequests = NumOfPendingRequest() + NumOfCompletedRequestst() + NumOfCancelledRequest();
            return AllRequests;
        }
        public int NumOfPendingRequest()
        {
            var PendingRequests = _Context.Bookings.Count(req=>req.RequestStatusId==1);   
            return PendingRequests;
        }
        public int NumOfCompletedRequestst()
        {
            var CompletedRequests = _Context.Bookings.Count(req => req.RequestStatusId == 2);
            return CompletedRequests;
        }
        public int NumOfCancelledRequest()
        {
            var CancelledRequests = _Context.Bookings.Count(req => req.RequestStatusId == 3);
            return CancelledRequests;
        }

       //public List<TopFiveSpecializationsDTO> TopFiveSpecializations()
       // {
       //     var TopFiveSpecializations = _Context.Bookings.Include(D => D.DoctorDetails)
       //                                        .ThenInclude(sp => sp.Specialization)                            
       //                                        .GroupBy(req =>req.DoctorDetails.Specialization)  
                                               
       //                                        .Select(Doc => new TopFiveSpecializationsDTO
       //                                        {
       //                                            FullName=Doc.

       //                                        }).Distinct().ToList();
       //     return TopFiveSpecializations;
       // }
    }
}
