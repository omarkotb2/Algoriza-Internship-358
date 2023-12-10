using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.AdminDTO.PatientDTO
{

    public class GetPatinetByIdDTO
    {
        public byte[]? Iamge { get; set; }
   
        public string FullName { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;


        public string PhoneNumber { get; set; } = string.Empty;  


        public string Gender { get; set; }


        [DataType(DataType.Time)]
        public DateTime DateOfBirth { get; set; }

        public string DoctorName {  get; set; } = string.Empty;

        public string DoctorSpecialize {  get; set; } = string.Empty;

        public string Day {  get; set; } = string.Empty;


        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public float Price {  get; set; } 
        public string DiscoundCode { get; set; } = string.Empty;
        public float FinalPrice {  get; set; } 
        public string RequestStatus { get; set; } = string.Empty;

      


    }
}
