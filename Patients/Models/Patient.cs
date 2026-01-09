using Library.ChartingSystem.DTO;
using Library.ChartingSystem.Services;
using System;
namespace Library.ChartingSystem.Models
{
    public class Patient
    {
        //getters and setters as well as members of the class
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Birthdate { get; set; }
        public string? Race { get; set; }
        public string? Gender { get; set; }
        public string? Medical { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Address: {Address}, Birthdate: {Birthdate}, Race: {Race}, Gender: {Gender}, Diagnosis and Prescriptions: {Medical}";
        }

        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public Patient(PatientDTO patientDTO)
        {
            Id = patientDTO.Id;
            Name = patientDTO.Name;
            Address = patientDTO.Address;
            Birthdate = patientDTO.Birthdate;
            Race = patientDTO.Race;
            Gender = patientDTO.Gender;
            Medical = patientDTO.Medical;
        }

        public Patient()
        {
        }

        public Patient(int id)
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
