using Library.ChartingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ChartingSystem.Services
{
    public class PhysicianServiceProxy
    {
        private List<Physician?> physicians;
        private PhysicianServiceProxy()
        {
            physicians = new List<Physician?>();
        }
        private static PhysicianServiceProxy? instance;
        private static readonly object instanceLock = new object();

        public static PhysicianServiceProxy Current
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new PhysicianServiceProxy();
                }
                return instance;
            }
        }
        public List<Physician?> Physicians => physicians;
        public Physician? AddorUpdate(Physician? physician)
        {
            if (physician == null)
            {
                return null;
            }
            if (physician.Id <= 0)
            {
                var maxPhysicianId = -1;
                if (physicians.Any())
                {
                    maxPhysicianId = physicians.Select(p => p?.Id ?? 0).Max();
                }
                else
                {
                    maxPhysicianId = 0;
                }
                physician.Id = ++maxPhysicianId;
                physicians.Add(physician);
            }
            else
            {
                var physicianToEdit = physicians.FirstOrDefault(b => (b?.Id ?? 0) == physician.Id);
                if (physicianToEdit != null)
                {
                    var index = physicians.IndexOf(physicianToEdit);
                    physicians.RemoveAt(index);
                    physicians.Insert(index, physician);
                }

            }
            return physician;
        }

        public Physician? Delete(int id)
        {
            var physicianToDelete = physicians
            .Where(b => b != null)
            .FirstOrDefault(b => (b?.Id ?? -1) == id);
            physicians.Remove(physicianToDelete);

            return physicianToDelete;
        }
    }
}
