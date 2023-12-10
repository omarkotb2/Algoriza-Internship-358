using DomainLayer.DTO.DoctorDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Repository.DoctorRepository.SettingRepository;
using ServiceLayer.DoctorService.DoctorBookingService;

namespace Vezeeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorSettingService _doctorSettingService;
        private readonly IDoctorBookingService _doctorBookingService ;

        public DoctorController(IDoctorSettingService doctorSettingService
                                , IDoctorBookingService doctorBookingService)
        {
            _doctorSettingService = doctorSettingService;
            _doctorBookingService = doctorBookingService;
        }

        [HttpGet]
        [Route("{id:int}/GetAllBookings")]
        public IActionResult GetAllBookings([FromRoute]int id) 
        {
            if (ModelState.IsValid)
            {
                var AllBookings = _doctorBookingService.GetAllBookings(id);
                if (AllBookings != null){

                 return Ok(AllBookings);
                }
                else
                {
                    return BadRequest();

                }
            
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        [Route("{Docid:int}/ConfirmCheckUp/AppointmentId")]
        public IActionResult ConfirmCheckUp([FromRoute]int Docid , [FromBody] int BookingId)
        {
            if (ModelState.IsValid)
            {
                bool ConfirmedBooking = _doctorBookingService.GetBookingById(Docid, BookingId);
                if (ConfirmedBooking)
                {
                    return StatusCode(200, true);
                }
                else
                {
                    return StatusCode(400, false);
                }

            }
          else
             {
                 return StatusCode(400, false);
             }


        }

        [HttpPost]
        [Route("{id}:int/Appointment")]
        public IActionResult Add([FromBody]AddAppointmentDTO NewModel ,[FromRoute]int id)
        {
            if (ModelState.IsValid)
            {
                bool doc =_doctorSettingService.Add(NewModel, id);
                if (doc)
                {

                    return StatusCode(200, true);
                }
                else
                {
                    return StatusCode(400, false);


                }

            }
            else
            {
                return StatusCode(400, false);


            }


        }

        [HttpPut]
        [Route("UpdateAppointment/{id:int}")]
        public IActionResult UpdateAppointment([FromRoute] int id, [FromBody] AddAppointmentDTO appointmentDTO)
        {
            if (ModelState.IsValid)
            {

                var Appointmnet = _doctorSettingService.UpdateAppointment(id, appointmentDTO);

                if (Appointmnet)
                {
                    return StatusCode(200, true);
                }
                else
                {
                    return StatusCode(400, false);
                }
            }
            else
            {
                return StatusCode(400, false);

            }

        }



        [HttpDelete]
        [Route("DeletAppointment/{id:int}")]
        public IActionResult DeletAppointment(int id)
        {
            var Appointmnet = _doctorSettingService.DeletAppointment(id);
            if (Appointmnet)
            {
                return StatusCode(200, true);
            }
            else
            {
                return StatusCode(400, false);
            }

        }
      

    }
}
