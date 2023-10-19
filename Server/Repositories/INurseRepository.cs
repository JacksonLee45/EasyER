using EasyER.Server.Models;

namespace EasyER.Server.Repositories
{
    public interface INurseRepository
    {
        public Nurse SaveNurse(Nurse nurse);

        public Nurse GetLoggedInNurse(string email);

        public List<Nurse> GetNurses();

        //public List<Nurse>GetActiveNurses();
    }
}
