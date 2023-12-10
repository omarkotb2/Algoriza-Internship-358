using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.AdminDTO.SettingDTO
{
    public class UpdateCouponDTO
    {
       
        [Required]
        public string DiscoundCode { get; set; } = string.Empty;
        [Required]
        public int NumberOfCompletedRequest { get; set; }
        [Required]
        public int DiscoundTypeId { get; set; }
        [Required]
        public string DiscoundValue { get; set; } = string.Empty;
    }
}
