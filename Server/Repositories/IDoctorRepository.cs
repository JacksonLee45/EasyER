using EasyER.Server.Models;

namespace EasyER.Server.Repositories
{
    public interface IDoctorRepository
    {
        public Doctor SaveDoctor(Doctor doctor);

        public List<Doctor> GetDoctors();

        public Doctor GetLoggedInDoctor(string email);

        public Doctor UpdateDoctor(Doctor doctor);

    }
}
