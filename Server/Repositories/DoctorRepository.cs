using EasyER.Server.Models;
using EasyER.Server.Data;

namespace EasyER.Server.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private IDoctorContext _context;

        public DoctorRepository(IDoctorContext context)
        {
            _context = context;
        }

        public Doctor SaveDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public List<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetLoggedInDoctor(string email)
        {
            return _context.Doctors.Where(d => d.Email == email).FirstOrDefault();
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            _context.Update(doctor);
            _context.SaveChanges();
            return doctor;
        }
    }
}
