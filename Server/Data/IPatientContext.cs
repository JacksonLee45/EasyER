using EasyER.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyER.Server.Data
{
    public interface IPatientContext
    {
        public DbSet<Patient> Patients { get; set; }

        void SaveChanges();

        public void Update(Patient patient);

    }
}
