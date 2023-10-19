using EasyER.Server.Models;

namespace EasyER.Server.Repositories
{
    public interface IPatientRepository
    {
        public Patient SavePatient(Patient patient);

        public List<Patient> GetActivePatients();

        public List<Patient> GetPatientQueue();

        public Patient UpdatePatient(Patient patient);
        Patient GetPatientById(int id);
        bool DeactivatePatient(int id);
    }
}
