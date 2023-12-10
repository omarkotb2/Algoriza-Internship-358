using DomainLayer.DTO.DoctorDTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.DoctorRepository.DoctorBookingRepository
{
    public interface IDoctorBookingRepository
    {
        List<GetAllBookingDTO> GetAllBookings(int id);
        bool ConfirmCheckUp(Booking booking);
        Booking GetBookingById(int id, int BookingId);
    }
}
