using EasyER.Server.Models;
using EasyER.Server.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyER.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : Controller
    {
        private IDoctorRepository DoctorRepository;

        public DoctorController(IDoctorRepository DoctorRepository)
        {
            this.DoctorRepository = DoctorRepository;
        }

        //-------------- Covered by test
        [HttpPost]
        [Route("new")]
        [Authorize("Admin")]
        public Doctor PostNewDoctor(Doctor doctor)
        {
            return DoctorRepository.SaveDoctor(doctor);
        }

        [HttpGet]
        [Route("all")]
        [Authorize("Admin")]
        public List<Doctor> GetAllDoctors()
        {
            return DoctorRepository.GetDoctors();
        }

        //-------------- Covered by test
        [HttpGet]
        [Route("id/{email}")]
        public Doctor GetDoctorId(string email)
        {
            return DoctorRepository.GetLoggedInDoctor(email);
        }

        //-------------- Covered by test
        [HttpPut]
        [Route("update")]
        public Doctor PutDoctor(Doctor doctor)
        {
            return DoctorRepository.UpdateDoctor(doctor);
        }
    }
}
