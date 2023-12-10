using DomainLayer.DTO.DoctorDTO;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository.AdminRepository.DashboardRepository;
using RepositoryLayer.Repository.AdminRepository.DoctorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.DoctorRepository.SettingRepository
{
    public class DoctorSettingService : IDoctorSettingService
        
    {
        private readonly IDoctorSettingRepository _doctorSettingRepository ;
        private readonly IAdminDoctorRepository _adminDoctorRepository;


        public DoctorSettingService(IDoctorSettingRepository adminSettingRepository,
                                    IAdminDoctorRepository adminDoctorRepository)                                        
        {
            _doctorSettingRepository = adminSettingRepository;
            _adminDoctorRepository = adminDoctorRepository;
        }

        public bool Add(AddAppointmentDTO NewModel,int id)
        {
            
            List<Appointment> appointmentsDays = new List<Appointment>();
            DoctorDetails Doctor = _adminDoctorRepository.GetDoctorById(id);

            if (Doctor == null)
            {
                return false;
            }
            else
            {

            Doctor.Price = NewModel.Price;


            foreach (var appointmentDay in NewModel.AppointmentDays)
            {

                foreach (var docTime in appointmentDay.DocTime)
                {
                    Appointment appointment = new Appointment()
                    {
                        DaysId = appointmentDay.DayId,
                        Hour = docTime,
                        DoctorDetailsId = Doctor.Id,
                    };

                    appointmentsDays.Add(appointment);

                }

            }

                try
                {
                    _doctorSettingRepository.AddNewAppointment(appointmentsDays);
                    _adminDoctorRepository.UpdateDoctor(Doctor);
                    return true;

                }
                catch (Exception)
                {

                    return false;
                }
            }
           
         
            
            

        }


        public List<Appointment> GetAppointmentById(int id)
        {
            List<Appointment> Appointment = _doctorSettingRepository.GetAppointmentById(id);
            if (Appointment != null) 
            {
              return Appointment;

            }
            else
            {
                return null;
            }
        }
        public bool DeletAppointment(int id)
        {

            List<Appointment> appoitnment = _doctorSettingRepository.GetAppointmentById(id);
           
            if (appoitnment.Any())
            {
                _doctorSettingRepository.DeletAppointment(appoitnment);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAppointment(int id , AddAppointmentDTO appointmentDTO)
        {
            List<Appointment> appointmentsDays = _doctorSettingRepository.GetAppointmentById(id);
            if (appointmentsDays.Any())
            {
                foreach (Appointment app in appointmentsDays)
                {

                    DoctorDetails Doctor = _adminDoctorRepository.GetDoctorById(app.DoctorDetails.UserId);


                    if (Doctor == null)
                    {
                        return false;
                    }
                    else
                    {

                        Doctor.Price = appointmentDTO.Price;


                        foreach (var appointmentDay in appointmentDTO.AppointmentDays)
                        {

                            foreach (var docTime in appointmentDay.DocTime)
                            {
                                Appointment NewAppointment = new Appointment()
                                {
                                    DaysId = appointmentDay.DayId,
                                    Hour = docTime,
                                    DoctorDetailsId = Doctor.Id,
                                };
                                
                               // DeletAppointment(id);
                                appointmentsDays.Clear();   
                                appointmentsDays.Add(NewAppointment);

                              _doctorSettingRepository.UpdateAppointment(appointmentsDays);
                               _adminDoctorRepository.UpdateDoctor(Doctor);

                            }

                        }
                    }

                   return true;
                }
               return true;
            }
            else
            {
                return false;
            }
        
          


        }


    }
}
