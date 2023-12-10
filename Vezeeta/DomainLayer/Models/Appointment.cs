using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [ForeignKey("DoctorDetails")]
        public int DoctorDetailsId { get; set; }
        public DoctorDetails DoctorDetails { get; set; } = default!;

        [ForeignKey("Days")]
        public int DaysId { get; set; }

        public Day Days { get; set; }= default!;

        public int Hour{ get; set;}
        
       

    }
}
