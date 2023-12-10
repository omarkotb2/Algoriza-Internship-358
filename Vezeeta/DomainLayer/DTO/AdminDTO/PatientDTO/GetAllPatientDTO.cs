using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.AdminDTO.PatientDTO
{
    public class GetAllPatientDTO
    {
         public byte[]? Iamge { get; set; } 
    
        public string FullName { get; set; } = string.Empty;

    
        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;


        public string Gender { get; set; } = string.Empty;


        public string DateOfBirth { get; set; } = string.Empty;
    }
}
