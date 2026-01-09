using Library.ChartingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ChartingSystem.Services
{
    public class AppointmentServiceProxy
    {
        private List<Appointment?> appointments;
        private AppointmentServiceProxy()
        {
            appointments = new List<Appointment?>();
        }
        private static AppointmentServiceProxy? instance;
        private static readonly object instanceLock = new object();
        public static AppointmentServiceProxy Current
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new AppointmentServiceProxy();
                }
                return instance;
            }
        }
        public List<Appointment?> Appointments => appointments;
        public Appointment? AddorUpdate(Appointment? appointment)
        {
            if (appointment == null)
            {
                return null;
            }

            var physicians = PhysicianServiceProxy.Current.Physicians;
            var patients = PatientServiceProxy.Current.Patients;

            Console.WriteLine("Choose a physician ID to create a appointment with: ");
            physicians.ForEach(Console.WriteLine);
            var userPhySelect = Console.ReadLine();

            //error output
            if (!int.TryParse(userPhySelect, out int physicianSelect) || !physicians.Any(p => p?.Id == physicianSelect))
            {
                Console.WriteLine("Invalid Id Try Again");
                return null;
            }

            Console.WriteLine("Choose a patient ID to create a appointment with the physician: ");
            patients.ForEach(Console.WriteLine);
            var userPatSelect = Console.ReadLine();

            if (!int.TryParse(userPatSelect, out int patientSelect) || !patients.Any(p => p?.Id == patientSelect))
            {
                Console.WriteLine("Invalid Id Try Again");
                return null;
            }

            appointment.patientId = patientSelect;

            //using the DateTime struct to get user input if it is correct
            Console.WriteLine("Enter appointment date in this format: YYYY-MM-DD):");
            var userDate = Console.ReadLine();
            Console.WriteLine("Enter appointment time in this format: HH:MM (Using Military Time 8-17)");
            var userTime = Console.ReadLine();
            if (DateTime.TryParse($"{userDate} {userTime}", out DateTime appointmentDateTime))
            {
                //checking if the date is mon-fri and time is 8am-5pm
                if (appointmentDateTime.DayOfWeek == DayOfWeek.Saturday || appointmentDateTime.DayOfWeek == DayOfWeek.Sunday || appointmentDateTime.Hour < 8 || appointmentDateTime.Hour >= 17)
                {
                    Console.WriteLine("Appointments can only be made from 8am-5pm on Mon-Friday. Please try again");
                    return null;
                }
                //nexted if statement to check if it is double booked
                bool DoubleBooked = appointments.Any(a => a?.physicianId == physicianSelect && a.AppointmentTime.Date == appointmentDateTime.Date && a.AppointmentTime.Hour == appointmentDateTime.Hour);
                if (DoubleBooked)
                {
                    Console.WriteLine("This physician is already booked at this time, please try again");
                    return null;
                }
                //if it isn't doubled book continue by adding it as well as updating the appointment ids
                else
                {
                    appointment.AppointmentTime = appointmentDateTime;
                    var maxAppointmentId = -1;
                    if (appointments.Any())
                    {
                        maxAppointmentId = appointments.Select(a => a?.Id ?? 0).Max();
                    }
                    else
                    {
                        maxAppointmentId = 0;
                    }
                    appointment.Id = ++maxAppointmentId;
                    appointments.Add(appointment);
                    Console.WriteLine("Appointment Created!");
                    return appointment;
                }
            }
            else
            {
                //the code does allow you to put in a random numbers this adds clarity letting the user know they inputted the wrong format
                Console.WriteLine("Invalid format.");
                return null;
            }

        }
        public Appointment? Delete(int id)
        {
            var appointmentToDelete = appointments
                .Where(b => b != null)
                .FirstOrDefault(b => (b?.Id ?? -1) == id);
            if (appointmentToDelete != null)
            {
                appointments.Remove(appointmentToDelete);
                Console.WriteLine($"Appointment #{id} deleted.");
            }
            else
            {
                Console.WriteLine($"Appointment #{id} not found.");
            }
            return appointmentToDelete;
        }
    }
}
