using DomainLayer.DTO.DoctorDTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.DoctorRepository.SettingRepository
{
    public interface IDoctorSettingRepository
    {
       
        bool AddNewAppointment(List<Appointment> NewAppointment);
        List<Appointment> GetAppointmentById(int id);
        void DeletAppointment(List<Appointment> appointment);
        bool UpdateAppointment(List<Appointment> NewModel);



    }
}
