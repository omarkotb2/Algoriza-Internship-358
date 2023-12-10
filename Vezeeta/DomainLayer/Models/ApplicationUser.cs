using DomainLayer.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;



namespace DomainLayer.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;

     
        public byte[]? Image { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("Gender")]
        public int Genderid { get; set; }
        public Gender Gender { get; set; } = default!;

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public IdentityRole<int> Role { get; set; } = default!;


    }
}
