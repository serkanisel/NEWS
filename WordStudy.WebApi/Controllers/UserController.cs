using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordStudy.WebApi.Interfaces;
using WordStudy.Data.Model;

namespace WordStudy.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsrRepository _userRepository;

        public UserController(IUsrRepository usrRepository)
        {
            _userRepository = usrRepository;
        }

        public IActionResult Get()
        {
            IEnumerable<Usr> users = _userRepository.GetAll();

            return Ok(users);
        }
    }
}