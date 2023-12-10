using DomainLayer.DTO.AdminDTO.DoctorDTO;
using DomainLayer.DTO.DoctorDTO;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.DoctorRepository.SettingRepository
{
    public class DoctorSettingRepository : IDoctorSettingRepository

    {
        private readonly ApplicationDbContext _Context;

        public DoctorSettingRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }






        public bool AddNewAppointment(List<Appointment> NewAppointment)
        {

            _Context.AddRange(NewAppointment);
            _Context.SaveChanges();
       
            return true;
        }


        public List<Appointment> GetAppointmentById(int id)
        {
            var appointmnetInDb = _Context.Appointments
                                           .Include(doc => doc.DoctorDetails)
                                           .Include(day=>day.Days)
                                           .Where(x=>x.DoctorDetailsId == id)
                                           .ToList();
                                           

            return appointmnetInDb;
        }
        public void DeletAppointment(List<Appointment> appointment)

        {
            _Context.RemoveRange(appointment);
            _Context.SaveChanges() ;
        }

        public bool UpdateAppointment(List<Appointment> UpdatedModel)
        {
            _Context.UpdateRange(UpdatedModel);
            _Context.SaveChanges();
            return true;
        }

       
    }
}
