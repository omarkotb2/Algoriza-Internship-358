using DomainLayer.DTO.AdminDTO.DashboardDTO;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository.AdminRepository.DashboardRepository;
using RepositoryLayer.Repository.AdminRepository.DoctorRepository;
using RepositoryLayer.Repository.AdminRepository.PatientRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AdminService.DashboardService
{
    public class AdminDashboardService:IAdminDashboardService
    {
        private readonly IAdminDoctorRepository _adminDoctorRepository;
        private readonly IAdminPatientRepository _adminPatientRepository;
        private readonly IAdminDashboardRepository _adminDashboardRepository;


        public AdminDashboardService(IAdminDoctorRepository adminDoctorRepository,
                                IAdminPatientRepository adminPatientRepository, 
                                IAdminDashboardRepository adminDashboardRepository)
        {
            _adminDoctorRepository = adminDoctorRepository;
            _adminPatientRepository = adminPatientRepository;
            _adminDashboardRepository = adminDashboardRepository;
        }

        public int NumOfDoctors(int page, int pageSize, string search)
        {
            return _adminDoctorRepository.GetDoctorDetails(page,pageSize,search).Count;
        }

        public int NumOfPatients(int page, int pageSize, string search)
        {
            return _adminPatientRepository.GetPatientDetails(page, pageSize,search).Count;
        }

        

        public NumOfRequestsDTO NumOfRequests( )
        {
            NumOfRequestsDTO NewModel = new NumOfRequestsDTO();
           int AllRequests = _adminDashboardRepository.NumOfAllRequests();
            int PendingRequests = _adminDashboardRepository.NumOfPendingRequest();
            int CompletedReuests = _adminDashboardRepository.NumOfCompletedRequestst();
            int CancelledRequests = _adminDashboardRepository.NumOfCancelledRequest();

          
            NewModel.TotalRequsts = AllRequests;
            NewModel.PendingReuests = PendingRequests;
            NewModel.CompletedReuests = CompletedReuests;
            NewModel.CancelledReuests = CancelledRequests;
    

            return NewModel;    

        }

        //public List<TopFiveSpecializationsDTO> TopFiveSpecializations()
        //{
        //    var TopFiveSpecializations = _adminDashboardRepository.TopFiveSpecializations();
        //    return TopFiveSpecializations;
        //}
    }
}
