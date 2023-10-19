using EasyER.Server.Models;
using EasyER.Server.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyER.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NurseController : Controller
    {
        private INurseRepository NurseRepository;

        public NurseController(INurseRepository NurseRepository)
        {
            this.NurseRepository = NurseRepository;
        }

        //-------------- Covered by test
        [HttpPost]
        [Route("new")]
        [Authorize("Admin")]
        public Nurse PostNewNurse(Nurse nurse)
        {
            return NurseRepository.SaveNurse(nurse);
        }

        [HttpGet]
        [Route("all")]
        [Authorize("Admin")]
        public List<Nurse> GetAllNurses()
        {
            return NurseRepository.GetNurses();
        }

        //-------------- Covered by test
        [HttpGet]
        [Route("id/{email}")] 
        public Nurse GetNurseId(string email)
        {
            return NurseRepository.GetLoggedInNurse(email);
        }
    }
}
