using DomainLayer.Enums;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.DoctorDTO
{
    public class AppointmentDayDTO
    { 
        public int  DayId  { get; set; }   
        public List<int> DocTime { get; set; }     

    }
}
