using Library.ChartingSystem.Models;
using Library.ChartingSystem.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.ChartingSystem.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Birthdate { get; set; }
        public string? Race { get; set; }
        public string? Gender { get; set; }
        public string? Medical { get; set; }

        public string Display
        {
            get
            {
                return ToString();
            }
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Address: {Address}, Birthdate: {Birthdate}, Race: {Race}, Gender: {Gender}, Diagnosis and Prescriptions: {Medical}";
        }

        public PatientDTO(Patient patient)
        {
            Id = patient.Id;
            Name = patient.Name;
            Address = patient.Address;
            Birthdate = patient.Birthdate;
            Race = patient.Race;
            Gender = patient.Gender;
            Medical = patient.Medical;
        }

        public PatientDTO()
        {

        }

        public PatientDTO(int id)
        {
            var patientCopy = PatientServiceProxy.Current.Patients.FirstOrDefault(b => (b?.Id ?? 0) == id);

            if (patientCopy != null)
            {
                Id = patientCopy.Id;
                Name = patientCopy.Name;
                Address = patientCopy.Address;
                Birthdate = patientCopy.Birthdate;
                Race = patientCopy.Race;
                Gender = patientCopy.Gender;
                Medical = patientCopy.Medical;
            }

        }
    }
}
