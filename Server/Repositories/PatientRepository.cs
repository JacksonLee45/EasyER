using EasyER.Server.Data;
using EasyER.Server.Models;

namespace EasyER.Server.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private IPatientContext _context;

        public PatientRepository(IPatientContext context)
        {
            _context = context;
        }


        public Patient SavePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }

        //Finds All Active Users so they can be simply list
        public List<Patient> GetActivePatients()
        {
            return _context.Patients.ToList().FindAll(p => p.IsActive);
        }


        //Builds the Queue out of Active Patients that are not yet being seen by a doctor
        public List<Patient> GetPatientQueue()
        {
            var query = from patient in _context.Patients
                        where patient.IsActive == true
                        &&
                        patient.IsBeingSeen == false
                        orderby patient.TraumaLevel, patient.TimeAdmitted
                        select patient;

            List <Patient> tempList = new List<Patient>();

            return tempList = query.ToList();
        }
        
        public Patient UpdatePatient(Patient patient)
        {
            _context.Update(patient);
            _context.SaveChanges();
            return patient;
        }

        public Patient? GetPatientById(int id) 
        {
            return _context.Patients.ToList().Find(p => p.PatientId == id);
        }

        public bool DeactivatePatient(int id)
        {
            Patient patient = _context.Patients.First(p => p.PatientId == id);
            if(patient == null)
            {
                return false;
            }
            else
            {
                patient.IsActive = false;
                UpdatePatient(patient);
                return true;
            }
        }
    }
}
