using Library.ChartingSystem.Data;
using Library.ChartingSystem.DTO;
using Library.ChartingSystem.Models;
using Library.ChartingSystem.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ChartingSystem.Services
{
    public class PatientServiceProxy
    {
        private List<PatientDTO?> patients;

        private PatientServiceProxy()
        {
            patients = new List<PatientDTO?>();
            var patientsResponse = new WebRequestHandler().Get("/Patient").Result;
            if (patientsResponse != null)
            {
                patients = JsonConvert.DeserializeObject<List<PatientDTO?>>(patientsResponse)
                           ?? new List<PatientDTO?>();
            }
        }
        private static PatientServiceProxy? instance;
        private static readonly object instanceLock = new object();
        public static PatientServiceProxy Current
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new PatientServiceProxy();
                }
                return instance;
            }
        }
        public List<PatientDTO?> Patients => patients;
        public async Task<PatientDTO?> AddorUpdate(PatientDTO? patient)
        {
            if (patient == null)
            {
                return null;
            }

            var patientPayload = await new WebRequestHandler().Post("/Patient", patient);
            var patientFromServer = JsonConvert.DeserializeObject<PatientDTO?>(patientPayload);

            if (patient.Id <= 0)
            {
                patients.Add(patientFromServer);
            }
            else
            {
                var patientToEdit = patients.FirstOrDefault(b => (b?.Id ?? 0) == patient.Id);
                if (patientToEdit != null)
                {
                    var index = patients.IndexOf(patientToEdit);

                    patients.RemoveAt(index);

                    patients.Insert(index, patientFromServer);
                }
            }

            return patientFromServer;
        }



        public PatientDTO? Delete(int id)
        {
            var response = new WebRequestHandler().Delete($"/Patient/{id}").Result;
            var patientToDelete = patients
                .Where(b => b != null)
                .FirstOrDefault(b => (b?.Id ?? -1) == id);
            patients.Remove(patientToDelete);

            return patientToDelete;
        }
        public async Task<List<PatientDTO>> Search(QueryRequest query)
        {
            var patientPayload = await new WebRequestHandler().Post("/Patient/Search", query);
            var patientFromServer = JsonConvert.DeserializeObject<List<PatientDTO?>>(patientPayload);

            patients = patientFromServer;
            return patients;
        }
    }
}
