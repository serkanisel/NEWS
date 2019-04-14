using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordStudy.WebApi.Interfaces;
using WordStudy.Data.Model;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using WordStudy.WebApi.Dtos;
using System.Security.Claims;

namespace WordStudy.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsrRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUsrRepository usrRepository, IMapper mapper)
        {
            _userRepository = usrRepository;
            _mapper = mapper;
        }

        [HttpGet("{GetAllAsync}")]
        public IActionResult GetAllAsync()
        {
            IEnumerable<Usr> users = _userRepository.GetAll();

            var userToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(userToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetAllUsersWithPhotos();

            var userToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(userToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Usr user = await _userRepository.GetUserWithPhotos(id);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody]UserForUpdateDto userForUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _userRepository.GetByIdAsync(id);

            _mapper.Map(userForUpdateDto, userFromRepo);

            try
            {
                _userRepository.Update(userFromRepo);
                return NoContent();
            }
            catch (Exception)
            {
                throw new Exception($"Updating user {id} failed on save");
            }
        }
    }
}