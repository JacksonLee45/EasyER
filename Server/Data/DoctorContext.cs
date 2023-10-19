using EasyER.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyER.Server.Data
{
    public class DoctorContext : DbContext, IDoctorContext
    {
        //public DbSet<Doctor> Doctors { get; set; } //initial DbSet when the doctors table was first migrated

        DbSet<Doctor> IDoctorContext.Doctors { get; set; }

        public DoctorContext(
            DbContextOptions<DoctorContext> options) : base(options)
        { }

        void IDoctorContext.SaveChanges() => base.SaveChanges();

        public void Update(Doctor doctor)
        {
            base.Update(doctor);
        }
    }
}