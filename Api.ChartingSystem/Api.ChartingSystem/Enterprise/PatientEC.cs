using Api.ChartingSystem.Database;
using Library.ChartingSystem.DTO;
using Library.ChartingSystem.Models;
using System.Reflection.Metadata;

namespace Api.ChartingSystem.Enterprise
{
    public class PatientEC
    {
        public IEnumerable<PatientDTO> GetPatients()
        {
            return Filebase.Current.Patients
                .Select(b => new PatientDTO(b))
                .OrderByDescending(b => b.Id)
                .Take(100);
        }
        public PatientDTO? GetById(int id)
        {
            var patient = Filebase.Current.Patients.FirstOrDefault(b => b.Id == id);
            return new PatientDTO(patient);
        }

        public PatientDTO? Delete(int id)
        {
            var patient = Filebase.Current.Patients.FirstOrDefault(b => b.Id == id);

            if (patient != null)
            {
                Filebase.Current.Delete("Patient", id.ToString());
            }

            return patient != null ? new PatientDTO(patient) : null;
        }


        public PatientDTO? AddOrUpdate(PatientDTO? patientDTO)
        {
            if (patientDTO == null)
            {
                return null;
            }
            var patient = new Patient(patientDTO);
            patientDTO = new PatientDTO(Filebase.Current.AddOrUpdate(patient));
            return patientDTO;
        }

        public IEnumerable<PatientDTO?> Search(string query)
        {
            return Filebase.Current.Patients.Where(
                        b => (b?.Name?.ToUpper()?.Contains(query?.ToUpper() ?? string.Empty) ?? false)
                        || (b?.Address?.ToUpper()?.Contains(query?.ToUpper() ?? string.Empty) ?? false)
                        || (b?.Birthdate?.ToUpper()?.Contains(query?.ToUpper() ?? string.Empty) ?? false)
                        || (b?.Race?.ToUpper()?.Contains(query?.ToUpper() ?? string.Empty) ?? false)
                        || (b?.Gender?.ToUpper()?.Contains(query?.ToUpper() ?? string.Empty) ?? false)
                        || (b?.Medical?.ToUpper()?.Contains(query?.ToUpper() ?? string.Empty) ?? false)
                    ).Select(b => new PatientDTO(b));
        }
    }
}