using Library.ChartingSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.ChartingSystem.Models
{
    public class Appointment
    {
        //getters and setters as well as members of the class
        public int Id { get; set; }
        public int patientId { get; set; }
        public int physicianId { get; set; }
        public DateTime AppointmentTime { get; set; }

        public string Display
        {
            get
            {
                return ToString();
            }
        }
        public Appointment()
        {

        }

        public Appointment(int id)
        {
            var appointmentCopy = AppointmentServiceProxy.Current.Appointments.FirstOrDefault(b => (b?.Id ?? 0) == id);
            if (appointmentCopy != null)
            {
                Id = appointmentCopy.Id;
                patientId = appointmentCopy.patientId;
                physicianId = appointmentCopy.physicianId;
                AppointmentTime = appointmentCopy.AppointmentTime;
            }
        }
    }
}