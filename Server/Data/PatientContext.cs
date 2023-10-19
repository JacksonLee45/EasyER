using Duende.IdentityServer.EntityFramework.Options;
using EasyER.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EasyER.Server.Data
{
    public class PatientContext : DbContext, IPatientContext
    {
        DbSet<Patient> IPatientContext.Patients { get; set; }


        public PatientContext(
            DbContextOptions<PatientContext> options) : base(options)
        { }

        void IPatientContext.SaveChanges() => base.SaveChanges();

        public void Update(Patient patient)
        {
            base.Update(patient);
        }

    }
}
