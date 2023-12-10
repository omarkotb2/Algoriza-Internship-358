using DomainLayer.DTO.DoctorDTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DoctorService.DoctorBookingService
{
    public interface IDoctorBookingService
    {
        List<GetAllBookingDTO> GetAllBookings(int id);
        bool GetBookingById(int id,int BookingId);
 


    }
}
