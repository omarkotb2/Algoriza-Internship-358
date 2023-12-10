using DomainLayer.LookupsTable_s;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class DoctorDetails
    {
        public int Id { get; set; }
        public float Price{ get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; } = default!;

        [ForeignKey("Specialization")]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; } = default!;


    }
}
