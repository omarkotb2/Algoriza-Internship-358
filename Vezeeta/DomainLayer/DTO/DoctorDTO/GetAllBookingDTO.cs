using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.DoctorDTO
{
    public class GetAllBookingDTO
    {
        public byte[] Image { get; set;} 
        public string PatientName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Appointment { get; set; }
        

    }
}
