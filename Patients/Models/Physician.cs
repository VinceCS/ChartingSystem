using Library.ChartingSystem.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.ChartingSystem.Models
{
    public class Physician
    {
        //getters and setters as well as members of the class
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? License { get; set; }
        public string? GraduationDate { get; set; }
        public string? Specialization { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, License: {License}, Graduation Date: {GraduationDate}, Specialization: {Specialization}";
        }
        public string Display
        {
            get
            {
                return ToString();
            }
        }
        public Physician()
        {

        }

        public Physician(int id)
        {
            var physicanCopy = PhysicianServiceProxy.Current.Physicians.FirstOrDefault(b => (b?.Id ?? 0) == id);
            if (physicanCopy != null)
            {
                Id = physicanCopy.Id;
                Name = physicanCopy.Name;
                License = physicanCopy.License;
                GraduationDate = physicanCopy.GraduationDate;
                Specialization = physicanCopy.Specialization;
            }
        }
    }
}
