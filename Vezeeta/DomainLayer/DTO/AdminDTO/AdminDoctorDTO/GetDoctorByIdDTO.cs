using DomainLayer.Enums;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.AdminDTO.DoctorDTO
{
    public class GetDoctorByIdDTO
    {
         public byte[]? image {  get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Specialize { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;

        [DataType(DataType.Time)]
        public DateTime DateOfBirth { get; set; }
    }
}
