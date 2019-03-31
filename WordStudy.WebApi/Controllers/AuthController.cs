﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WordStudy.Data.Model;
using WordStudy.WebApi.Dtos;
using WordStudy.WebApi.Interfaces;

namespace WordStudy.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo,IConfiguration config)
        {
            _repo = repo;
            _config= config;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            try
            {
                //valite request
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

                if (await _repo.UserExists(userForRegisterDto.Username))
                    return BadRequest("Username already exists");

                var userToCreate = new Usr
                {
                    UserName = userForRegisterDto.Username,
                    Name=userForRegisterDto.Name,
                    SurName=userForRegisterDto.Surname
                };

                var createUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {
            throw new Exception("Computer says no!");

            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            Usr usr = new Usr();
            
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}