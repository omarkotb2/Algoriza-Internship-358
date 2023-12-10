using DomainLayer.LookupsTable_s;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public float  FinalPrice{ get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }= default!;

        [ForeignKey("DoctorDetails")]
        public int DoctorDetailsID { get; set; }
        public DoctorDetails DoctorDetails { get; set; } = default!;

        [ForeignKey("Coupon")]
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; } = default!;

        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }= default!;

        [ForeignKey("RequestStatus")]
        public int RequestStatusId { get; set; }
        public RequestStatu RequestStatus { get; set; }= default!;
        
        public int  Hour {  get; set; }

    }
}
