using EasyER.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyER.Server.Data
{
    public interface INurseContext
    {
        public DbSet<Nurse> Nurses { get; set; }

        void SaveChanges();

    }
}
