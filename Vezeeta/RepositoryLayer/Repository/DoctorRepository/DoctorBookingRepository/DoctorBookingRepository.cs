using DomainLayer.DTO.DoctorDTO;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.DoctorRepository.DoctorBookingRepository
{
    public class DoctorBookingRepository : IDoctorBookingRepository
    {

        private readonly ApplicationDbContext _Context;

        public DoctorBookingRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }


        public List<GetAllBookingDTO>  GetAllBookings(int id)
        {
            var BookingsInDB = _Context.Bookings
                                         .Include(patient => patient.User)
                                         .ThenInclude(gen => gen.Gender)
                                         .Include(doc => doc.DoctorDetails)
                                         .ThenInclude(sp => sp.Specialization)
                                         .Include(appointment => appointment.Appointment)
                                         .Include(status => status.RequestStatus)
                                         .Where(docId=>docId.DoctorDetailsID == id) 
                                         .Select(BookDto => new GetAllBookingDTO
                                         {
                                             PatientName = BookDto.User.FirstName + " " + BookDto.User.LastName,
                                             //Image = BookDto.User.Image,
                                             Age =(DateTime.Now.Year- BookDto.User.DateOfBirth.Year),
                                             Phone = BookDto.User.PhoneNumber,
                                             Email = BookDto.User.Email,
                                             Appointment = BookDto.AppointmentId
                                         }).ToList() ;
            return BookingsInDB;
        }

        public Booking GetBookingById(int id, int BookingId )
        {
            var BookingsInDB = _Context.Bookings 
                                          .Where(docid => docid.DoctorDetailsID == id)
                                          .FirstOrDefault(Book => Book.Id == BookingId);
                                         
            return BookingsInDB;
  

        }  
        public bool ConfirmCheckUp(Booking booking)
        {

            _Context.Update(booking);
            _Context.SaveChanges();
            return true;

        }
    }
}
