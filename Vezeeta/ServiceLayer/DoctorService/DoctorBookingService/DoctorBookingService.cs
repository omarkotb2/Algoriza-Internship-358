using DomainLayer.DTO.DoctorDTO;
using DomainLayer.Models;
using RepositoryLayer.Repository.DoctorRepository.DoctorBookingRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DoctorService.DoctorBookingService
{
    public class DoctorBookingService : IDoctorBookingService
    {

        private readonly IDoctorBookingRepository _doctorBookingRepository;
        public DoctorBookingService(IDoctorBookingRepository doctorBookingRepository)
        {
            _doctorBookingRepository = doctorBookingRepository;
                
        }

       

        public List<GetAllBookingDTO> GetAllBookings(int id )
        {
            List<GetAllBookingDTO> allBookingDTO = new List<GetAllBookingDTO>();    
            List<GetAllBookingDTO> BookinginDB =  _doctorBookingRepository.GetAllBookings(id);
            if (BookinginDB != null)
            {
                foreach (var booking in BookinginDB)
                {
                    foreach (var item in allBookingDTO)
                    {

                        item.Image = booking.Image;
                        item.PatientName = booking.PatientName;
                        item.Age = booking.Age;
                        item.Phone = booking.Phone;
                        item.Email = booking.Email;
                        item.Appointment = booking.Appointment;
                    }
                    
 
                }
                    return BookinginDB; 


            }
            else
            {
                return null;
            }

        }
        public bool GetBookingById(int id, int BookingId)
        {
            Booking BookedAppointment = _doctorBookingRepository.GetBookingById(id, BookingId);
            if (BookedAppointment != null && BookedAppointment.RequestStatusId == 2)
            {
                  BookedAppointment.RequestStatusId = 3;
                _doctorBookingRepository.ConfirmCheckUp(BookedAppointment);
                

                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
