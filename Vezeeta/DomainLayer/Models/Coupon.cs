using DomainLayer.LookupsTable_s;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Coupon
    {
        public int Id { get; set; }

      
        public string DiscoundCode { get; set; } = string.Empty;
        public string DiscoundValue { get; set; }= string.Empty;
        public int NumberOfCompletedRequest { get; set; }

        [ForeignKey("DiscountType")]
        public int DiscountTypeId { get; set; }
        public DiscountType DiscountType { get; set; } = default!;

        public bool IsActive { get; set; } = true;

    }
}
