using EasyER.Server.Models;
using EasyER.Server.Data;

namespace EasyER.Server.Repositories
{
    public class NurseRepository : INurseRepository
    {
        private INurseContext _context;

        public NurseRepository(INurseContext context)
        {
            _context = context;
        }

        public List<Nurse> GetNurses()
        {
            return _context.Nurses.ToList();
        }

        public Nurse SaveNurse(Nurse nurse)
        {
            _context.Nurses.Add(nurse);
            _context.SaveChanges();
            return nurse;
        }

        public Nurse GetLoggedInNurse(string email)
        {
            return _context.Nurses.Where(n => n.Email == email).Single();
        }
    }
}
