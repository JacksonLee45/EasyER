using EasyER.Server.Models;
using EasyER.Server.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyER.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PatientController : Controller
    {

        private IPatientRepository PatientRepository;

        public PatientController(IPatientRepository PatientRepository)
        {
            this.PatientRepository = PatientRepository;
        }

        //-------------- Covered by test
        [HttpGet]
        [Route("all")]
        public List<Patient> GetAllActivePatients()
        {
            return PatientRepository.GetActivePatients();
        }

        //-------------- Covered by test
        [HttpGet]
        [Route("queue")]  
        public List<Patient> GetPatientQueue()
        {
            return PatientRepository.GetPatientQueue();
        }

        //-------------- Covered by test
        [HttpGet]
        [Route("{id}")]
        public Patient GetPatientById(int id)
        {
            return PatientRepository.GetPatientById(id);
        }

        //-------------- Covered by test
        [HttpPost]
        [Route("new")]
        public Patient PostNewPatient(Patient patient)
        {
            return PatientRepository.SavePatient(patient);
        }

        //-------------- Covered by test
        [HttpPut]
        [Route("update")]
        public Patient PutPatient(Patient patient)
        {
            return PatientRepository.UpdatePatient(patient);
        }


        //-------------- Covered by test
        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeactivatePatient(int id)
        {
            return PatientRepository.DeactivatePatient(id);
        }
    }
}
