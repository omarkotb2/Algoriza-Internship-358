
using DomainLayer.DTO.AdminDTO.DashboardDTO;
using DomainLayer.DTO.AdminDTO.DoctorDTO;
using DomainLayer.DTO.AdminDTO.SettingDTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Repository.AdminRepository.PatientRepository;
using RepositoryLayer.Repository.AdminRepository.SettigRepository;
using ServiceLayer.AdminService.DashboardService;
using ServiceLayer.AdminService.DoctorServices;
using ServiceLayer.AdminService.PatientService;

namespace Vezeeta.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminDoctorService _adminDoctorService;
        private readonly IAdminPatientService _adminPatientService;
        private readonly IAdminSettingService _adminSettingService;
        private readonly IAdminDashboardService _adminDashbordService;

        public AdminController(IAdminDoctorService adminDoctorService,
                                IAdminPatientService adminPatientService,
                                IAdminSettingService adminSettingService,
                                IAdminDashboardService adminDashbordService)
        {
            _adminDoctorService = adminDoctorService;
            _adminPatientService = adminPatientService;
            _adminSettingService = adminSettingService;
            _adminDashbordService = adminDashbordService;
        }


        //------- Start (Dashboard) ----------//

        [HttpGet]
        [Route("NumOfDoctors")]
        public IActionResult NumOfDoctors(int page, int pageSize, string search)
        {
            var DocNumber = _adminDashbordService.NumOfDoctors(page , pageSize ,search);
            return Ok(DocNumber);
        }
        [HttpGet]
        [Route("NumOfPatients")]
        public IActionResult NumOfPatients(int page, int pageSize, string search)
        {
            var PatiensNum = _adminDashbordService.NumOfPatients(page,pageSize,search);
            return Ok(PatiensNum);
        }
        [HttpGet]
        [Route("NumOfRequests")]
        public IActionResult NumOfRequests()
        {
            if (ModelState.IsValid)
            {
                var NumOfRequests = _adminDashbordService.NumOfRequests();
                return Ok(NumOfRequests);

            }
            else
            {
                return BadRequest();
            }

        }

        //[HttpGet]
        //[Route("Top 5 Specializations")]
        //public IActionResult TopFiveSpecializations()
        //{

        //    var TopFiveSpecializations = _adminDashbordService.TopFiveSpecializations();
        //    return Ok(TopFiveSpecializations);

        //}



        //------- End ( Dashboard) ----------//



        //------- Start (Doctors) ----------//

        [HttpGet]
        public IActionResult GetAllDoctor(int page = 1, int pageSize = 5, string search = "")
        {

            List<AllDoctorDetailsDTO> Doc = _adminDoctorService.GetDoctorDetails(page, pageSize, search);
            return Ok(Doc);

        }


        [HttpGet]
        [Route("GetDoctorByID/{id:int}")]
        public IActionResult GetDoctorByID(int id)
        {

            var doc = _adminDoctorService.GetDoctorById(id);
            if (doc == null)
            {
                return BadRequest();

            }
            return Ok(doc);

        }

        [HttpPost]
        [Route("CreateDoctor")]
        public IActionResult CreateDoctor([FromForm] CreateNewDoctorDTO NewModel)
        {
            if (ModelState.IsValid == true)
            {
                _adminDoctorService.CreateDoctor(NewModel);
                return StatusCode(200, true);
            }
            else return StatusCode(400, false);


        }

        [HttpPut]

        [Route("EditDoctor/{id:int}" )]
        public IActionResult EditDoctor([FromRoute] int id, [FromForm] UpdateDoctorDTO NewModel)
        {
            if (ModelState.IsValid ==true)
            {
                
                _adminDoctorService.UpdateDoctor(NewModel, id);
                    return StatusCode(200, true);
            }
            else return StatusCode(400, false);

        }
        [HttpDelete]
        [Route("DeleteDoctor")]
        public IActionResult DeleteDoctor(int id)
        {
            var DocTodDelete = _adminDoctorService.DeleteDoctor(id); 
            if (DocTodDelete)
            {

                return StatusCode(200,true);

            }
            else return StatusCode(400,false);

        }

        //------- End (Doctors) ----------//




        //----- Start (Patients) --------//

        [HttpGet]
        [Route("GetAllPatients")]
        public IActionResult GetAllPatients(int page = 1, int pageSize = 5, string search = "")
        {

            var Patients = _adminPatientService.GetPatientDetails(page,pageSize,search);
            return Ok(Patients);

        }

        [HttpGet]
        [Route("GetPatientById/{id:int}")]
        public IActionResult GetPatientById(int id)
        {

            var Patient = _adminPatientService.GetPatientById(id);
            if (Patient == null)
            {
                return BadRequest();

            }
            return Ok(Patient);

        }


        //----- End (Patients) --------//




        //----- Start (Setting) --------//

        [HttpPost]
        [Route("CreateNewCopuon")]
        public IActionResult CreateNewCopuon([FromForm] AddCouponDTO NewModel)
        {
            if (ModelState.IsValid)
            {
                _adminSettingService.AddCoupon(NewModel);
                return StatusCode(200,true );

            }
            else return StatusCode(400, false);       

        }
        [HttpPut]
        [Route("UpdateCoupon/{id:int}")]
        public IActionResult UpdateCoupon([FromRoute]int id,[FromForm] UpdateCouponDTO CouponDTO)
        {
            if (ModelState.IsValid)
            {
                _adminSettingService.UpdateCoupon(CouponDTO,  id);
                return StatusCode(200,true);
            }
            else
            {
                return StatusCode(400, false);
            }

        }

        [HttpDelete]
        [Route("DeleteCoupon/{id:int}")]
        public IActionResult DeleteCoupon(int id)
        {
              var CouponToDelete=  _adminSettingService.DeleteCoupon(id);
            if (CouponToDelete)
            {
                return StatusCode(200,true);
            }
            else
            {
                return StatusCode(400,false);
            }
        }
        [HttpPut]
        [Route("DeactiveCoupon/{id:int}")]

        public IActionResult DeactiveCoupon (int id)
        {
            var Coupon = _adminSettingService.DeactiveCoupon(id);
            if (Coupon)
            {
                return StatusCode(200, true);
            }
            else
            {
                return StatusCode(400, false);
            }

        }



        //----- End (Setting) --------//





    }
}   
