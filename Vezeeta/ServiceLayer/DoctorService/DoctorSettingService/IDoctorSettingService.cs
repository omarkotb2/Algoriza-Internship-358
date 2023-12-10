using DomainLayer.DTO.DoctorDTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.DoctorRepository.SettingRepository
{
    public interface IDoctorSettingService
    {
        bool Add(AddAppointmentDTO NewModel, int id);
        List<Appointment> GetAppointmentById(int id);
        bool DeletAppointment(int id);
        bool UpdateAppointment(int id , AddAppointmentDTO NewModel);


    }
}
