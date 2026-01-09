using Library.ChartingSystem.Models;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace Api.ChartingSystem.Database
{
    public static class FakeDatabase
    {
        public static List<Patient> Patients = new List<Patient>
        {
            new Patient {Id = 1, Name = "First", Address = "1 First Street", Birthdate = "1/1/2001", Race = "Asian", Gender = "Male", Medical ="None" },
            new Patient {Id = 2, Name = "First", Address = "1 First Street", Birthdate = "1/1/2001", Race = "Asian", Gender = "Male", Medical ="None" },
            new Patient {Id = 3, Name = "First", Address = "1 First Street", Birthdate = "1/1/2001", Race = "Asian", Gender = "Male", Medical ="None" }
        };
    }
}
