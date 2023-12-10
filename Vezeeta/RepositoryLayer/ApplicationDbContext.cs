using DomainLayer.Enums;
using DomainLayer.LookupsTable_s;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole<int>,int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Appointment> Appointments {  get; set; }
        public DbSet<Booking> Bookings{ get; set; }
        public DbSet<Coupon> Coupons{ get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<DiscountType> DiscountTypes { get; set; }
        public DbSet<DoctorDetails> DoctorDetails{ get; set; }
        public DbSet<Gender> Genders { get; set; }
       
      

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ApplicationUser>()
            .HasData(new ApplicationUser
            {
                Id= 1 ,
                FirstName = "Admin",
                LastName = "Admin",
                Image = null,
                DateOfBirth = new DateTime(1990,12 ,25),
                Genderid = 1,
                RoleId = 1,

            }) ;



                builder.Entity<Day>()
                .HasData(new Day[]
                {
                        new Day { Id =(int)DaysEnum.Saturday, Name = "Saturday" },
                        new Day { Id =(int)DaysEnum.Sunday, Name = "Sunday" },
                        new Day { Id =(int)DaysEnum.Monday, Name = "Monday" },
                        new Day { Id =(int)DaysEnum.Tuesday, Name = "Tuesday" },
                        new Day { Id =(int)DaysEnum.Wednesday, Name = "Wednesda" },
                        new Day { Id =(int)DaysEnum.Thursday, Name = "Thursday" },
                        new Day { Id =(int)DaysEnum.Friday, Name = "Friday" }

                });

            builder.Entity<DiscountType>()
                .HasData(new DiscountType[]
                {
                        new DiscountType { Id = (int)DiscountTypeEnum.Percentage, Name = "Percentage" },
                        new DiscountType { Id = (int)DiscountTypeEnum.Value, Name = "Value" },
                });

            builder.Entity<Gender>()
                .HasData(new Gender[]
                {
                        new Gender { Id = (int)GenderEnum.Male, Name = "Male" },
                        new Gender { Id =(int)GenderEnum.Female, Name = "Female" },
                });
            
            builder.Entity<RequestStatu>()
                .HasData(new RequestStatu[]
                {
                        new RequestStatu { Id = 1, Name = "Pending" },
                        new RequestStatu { Id = 2, Name = "Completed " },
                        new RequestStatu { Id = 3, Name = "Cancelled" },
                });
            
            builder.Entity<IdentityRole<int>>()
                .HasData(new IdentityRole<int>[]
                {
                        new IdentityRole<int> { Id =1, Name = "Admin" },
                        new IdentityRole<int>{ Id = 2, Name = "Doctor" },
                        new IdentityRole<int> { Id = 3, Name = "Patient" },
                });

            builder.Entity<Specialization>()
                .HasData(new Specialization[]
                {

                        new Specialization { Id = 1, Name = "Oculist" },
                        new Specialization { Id = 2, Name = "Cardiology" },
                        new Specialization { Id = 3, Name = "Dermatology" },
                        new Specialization { Id = 4, Name = "Oncologist" },
                        new Specialization { Id = 5, Name = "Internist" },
                        new Specialization { Id = 6, Name = "dentist" },
                        new Specialization { Id = 7, Name = "Otorhinolaryngologist" },
                        new Specialization { Id = 8, Name = "Orthopedic " },
                        new Specialization { Id = 9, Name = "Neurologist" },

                });


          

            base.OnModelCreating(builder);
        }





    }
}
