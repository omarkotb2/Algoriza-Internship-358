﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.AdminDTO.DoctorDTO
{
    public class UpdateDoctorDTO
    {

        public byte[]? Iamge { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public int SpecializeID { get; set; }

        [Required]
        public int GenderID { get; set; }
        [Required]
        public string DateOfBirth { get; set; } = string.Empty;
    }
}
