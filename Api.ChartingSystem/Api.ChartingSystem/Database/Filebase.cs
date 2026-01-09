using Api.ChartingSystem.Enterprise;
using Library.ChartingSystem.Models;
using Newtonsoft.Json;
using System.Reflection.Metadata;

namespace Api.ChartingSystem.Database
{
    public class Filebase
    {
        private string _root;
        private string _patientRoot;
        private static Filebase _instance;


        public static Filebase Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = @"C:\temp";
            _patientRoot = $"{_root}\\Patients";
        }

        public int LastPatientKey
        {
            get
            {
                if (Patients.Any())
                {
                    return Patients.Select(x => x.Id).Max();
                }
                return 0;
            }
        }

        public Patient AddOrUpdate(Patient patient)
        {
            if (patient.Id <= 0)
            {
                patient.Id = LastPatientKey + 1;
            }

            string path = $"{_patientRoot}\\{patient.Id}.json";


            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(patient));

            return patient;
        }

        public List<Patient> Patients
        {
            get
            {
                var root = new DirectoryInfo(_patientRoot);
                var _blogs = new List<Patient>();
                foreach (var patientFile in root.GetFiles())
                {
                    var patient = JsonConvert
                        .DeserializeObject<Patient>
                        (File.ReadAllText(patientFile.FullName));
                    if (patient != null)
                    {
                        _blogs.Add(patient);
                    }

                }
                return _blogs;
            }
        }


        public bool Delete(string type, string id)
        {
            if (type == "Patient")
            {
                string path = $"{_patientRoot}\\{id}.json";

                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }

                return false;
            }

            return false;
        }
    }



}