using System.Reflection.Metadata;
using Library.ChartingSystem.Models;
using System;
using System.Runtime.InteropServices;
using Library.ChartingSystem.Services;


namespace ChartingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creating all the objects to be used
            Console.WriteLine("Welcome to the the medical charting system!");
            List<Patient?> patients = PatientServiceProxy.Current.Patients;
            List<Physician?> physicians = PhysicianServiceProxy.Current.Physicians;
            List<Appointment?> appointments = AppointmentServiceProxy.Current.Appointments;
            //creating a cont variable to keep the loop running
            bool cont = true;

            //do while loop
            do
            {
                Console.WriteLine("a. Create a Patient");
                Console.WriteLine("b. Create a Physician");
                Console.WriteLine("c. Create a Appointment");
                Console.WriteLine("d. Add a medical note");
                Console.WriteLine("e. Print All");
                Console.WriteLine("f. Update Patient");
                Console.WriteLine("g. Delete Patient");
                Console.WriteLine("h. Update Physician");
                Console.WriteLine("i. Delete Physician");
                Console.WriteLine("j. Update Appointment");
                Console.WriteLine("k. Delete Appointment");
                Console.WriteLine("q. Quit");
                
                //reading user input
                var userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "A":
                    case "a":
                        { 
                            var patient = new Patient();
                            Console.Write("Name: "); patient.Name = Console.ReadLine();
                            Console.Write("Address: "); patient.Address = Console.ReadLine();
                            Console.Write("Birthdate: "); patient.Birthdate = Console.ReadLine();
                            Console.Write("Race: "); patient.Race = Console.ReadLine();
                            Console.Write("Gender: "); patient.Gender = Console.ReadLine();

                            PatientServiceProxy.Current.AddorUpdate(patient);
                            break;
                        }
                    case "B":
                    case "b":
                        {
                            var physician = new Physician();
                            Console.Write("Name: "); physician.Name = Console.ReadLine();
                            Console.Write("License: "); physician.License = Console.ReadLine();
                            Console.Write("Graduation Date: "); physician.GraduationDate = Console.ReadLine();
                            Console.Write("Specialization: "); physician.Specialization = Console.ReadLine();

                            PhysicianServiceProxy.Current.AddorUpdate(physician);
                            break;
                        }
                        

                    case "C":
                    case "c":
                        {
                            var appointment = new Appointment();
                            AppointmentServiceProxy.Current.AddorUpdate(appointment);
                            break;
                        }
                    case "D":
                    case "d":
                        { //choosing which patient to update
                            Console.WriteLine("Select a patient to add a medical note to: ");
                            PatientServiceProxy.Current.Patients.ForEach(Console.WriteLine);
                            if (int.TryParse(Console.ReadLine(), out int patId))
                            {
                                var pat = PatientServiceProxy.Current.Patients.FirstOrDefault(p => p?.Id == patId);
                                if (pat != null)
                                {
                                    Console.Write("Enter medical note: ");
                                    pat.Medical = Console.ReadLine();
                                    PatientServiceProxy.Current.AddorUpdate(pat);
                                }
                            }
                            break;
                        }
                       
                    case "E":
                    case "e":
                        {
                            Console.WriteLine("\nPatients:");
                            PatientServiceProxy.Current.Patients.ForEach(Console.WriteLine);

                            Console.WriteLine("\nPhysicians:");
                            PhysicianServiceProxy.Current.Physicians.ForEach(Console.WriteLine);

                            Console.WriteLine("\nAppointments:");
                            AppointmentServiceProxy.Current.Appointments.ForEach(Console.WriteLine);
                            break;
                        }
                        

                    case "F":
                    case "f":
                        {
                            Console.WriteLine("Select a patient ID to update:");
                            PatientServiceProxy.Current.Patients.ForEach(Console.WriteLine);
                            if (int.TryParse(Console.ReadLine(), out int updatePatId))
                            {
                                var pat = PatientServiceProxy.Current.Patients.FirstOrDefault(p => p?.Id == updatePatId);
                                if (pat != null)
                                {
                                    Console.Write("New Name (Enter to skip): ");
                                    var input = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(input)) pat.Name = input;

                                    Console.Write("New Address: "); 
                                    input = Console.ReadLine(); 
                                    if (!string.IsNullOrEmpty(input)) 
                                        pat.Address = input;
                                    Console.Write("New Birthdate: "); 
                                    input = Console.ReadLine(); 
                                    if (!string.IsNullOrEmpty(input)) 
                                        pat.Birthdate = input;
                                    Console.Write("New Race: "); 
                                    input = Console.ReadLine(); 
                                    if (!string.IsNullOrEmpty(input)) 
                                        pat.Race = input;
                                    Console.Write("New Gender: "); 
                                    input = Console.ReadLine(); 
                                    if (!string.IsNullOrEmpty(input)) 
                                        pat.Gender = input;

                                    PatientServiceProxy.Current.AddorUpdate(pat);
                                }
                            }
                            break;
                        }
                       
                    case "G":
                    case "g":
                        {
                            Console.WriteLine("Select a patient ID to delete:");
                            PatientServiceProxy.Current.Patients.ForEach(Console.WriteLine);
                            if (int.TryParse(Console.ReadLine(), out int updatePatId))
                            {
                                var pat = PatientServiceProxy.Current.Patients.FirstOrDefault(p => p?.Id == updatePatId);
                                if (pat != null)
                                {
                                    Console.Write("New Name (Enter to skip): ");
                                    var input = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(input)) pat.Name = input;

                                    Console.Write("New Address: ");
                                    input = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(input)) 
                                        pat.Address = input;
                                    Console.Write("New Birthdate: "); 
                                    input = Console.ReadLine(); 
                                    if (!string.IsNullOrEmpty(input)) 
                                        pat.Birthdate = input;
                                    Console.Write("New Race: "); 
                                    input = Console.ReadLine(); 
                                    if (!string.IsNullOrEmpty(input)) 
                                        pat.Race = input;
                                    Console.Write("New Gender: ");
                                    input = Console.ReadLine(); 
                                    if (!string.IsNullOrEmpty(input)) 
                                        pat.Gender = input;

                                    PatientServiceProxy.Current.AddorUpdate(pat);
                                }
                            }
                            break;
                        }
                        
                    case "H":
                    case "h":
                        {
                            Console.WriteLine("Select a physician ID to update:");
                            PhysicianServiceProxy.Current.Physicians.ForEach(Console.WriteLine);
                            if (int.TryParse(Console.ReadLine(), out int phyId))
                            {
                                var phy = PhysicianServiceProxy.Current.Physicians.FirstOrDefault(p => p?.Id == phyId);
                                if (phy != null)
                                {
                                    Console.Write("New Name (Enter to skip): "); 
                                    var input = Console.ReadLine(); 
                                    if (!string.IsNullOrEmpty(input)) 
                                        phy.Name = input;
                                    Console.Write("New License: "); 
                                    input = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(input)) 
                                        phy.License = input;
                                    Console.Write("New Graduation Date: "); 
                                    input = Console.ReadLine(); 
                                    if (!string.IsNullOrEmpty(input)) 
                                        phy.GraduationDate = input;
                                    Console.Write("New Specialization: "); 
                                    input = Console.ReadLine(); 
                                    if (!string.IsNullOrEmpty(input)) 
                                        phy.Specialization = input;

                                    PhysicianServiceProxy.Current.AddorUpdate(phy);
                                }
                            }
                            break;
                        }
                        
                    case "I":
                    case "i":
                        {
                            Console.WriteLine("Select a physician ID to delete:");
                            PhysicianServiceProxy.Current.Physicians.ForEach(Console.WriteLine);
                            if (int.TryParse(Console.ReadLine(), out int delPhyId))
                            {
                                PhysicianServiceProxy.Current.Delete(delPhyId);
                            }
                            break;
                        }
                    case "J":
                    case "j":
                        {
                            Console.WriteLine("Select an appointment ID to update:");
                            AppointmentServiceProxy.Current.Appointments.ForEach(Console.WriteLine);
                            if (int.TryParse(Console.ReadLine(), out int updAppId))
                            {
                                var app = AppointmentServiceProxy.Current.Appointments.FirstOrDefault(a => a?.Id == updAppId);
                                if (app != null)
                                {
                                    AppointmentServiceProxy.Current.AddorUpdate(app);
                                }
                            }
                            break;
                        
                        }
                        
                        
                    case "K":
                    case "k":
                        {
                            Console.WriteLine("Select an appointment ID to delete:");
                            AppointmentServiceProxy.Current.Appointments.ForEach(Console.WriteLine);
                            if (int.TryParse(Console.ReadLine(), out int delAppId))
                            {
                                AppointmentServiceProxy.Current.Delete(delAppId);
                            }
                            break;
                        }
                        
                    case "Q":
                    case "q":
                        {
                            //changes cont to false and quits the loop
                            cont = false;
                            break;
                        }

                    default:
                        {
                            //if the user inputs a wrong symbol prints an error statement
                            Console.WriteLine("Error Try Again");
                            break;
                        }
                        
                }
            } while (cont);
        }
    }
}
