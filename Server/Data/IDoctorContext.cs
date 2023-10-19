using EasyER.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyER.Server.Data
{
    public interface IDoctorContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        void SaveChanges();

        public void Update(Doctor doctor);
    }
}