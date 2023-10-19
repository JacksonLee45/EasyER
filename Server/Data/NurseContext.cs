using EasyER.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyER.Server.Data
{
    public class NurseContext : DbContext, INurseContext
    {
        DbSet<Nurse> INurseContext.Nurses { get; set; }

        public NurseContext(
            DbContextOptions<NurseContext> options) : base(options)
        { }

        void INurseContext.SaveChanges() => base.SaveChanges();
    }
}
