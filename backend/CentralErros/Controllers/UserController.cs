using AutoMapper;
using CentralErros.DTOs;
using CentralErros.Models;
using CentralErros.Services;
<<<<<<< HEAD
using Microsoft.AspNetCore.Cors;
=======
using Microsoft.AspNetCore.Authorization;
>>>>>>> bbc9b386731dca1d405fb56b77c278a6ed19ac5d
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CentralErros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService service;
        private readonly IMapper mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // POST: api/User
        [HttpPost]
<<<<<<< HEAD
=======
        [AllowAnonymous]
>>>>>>> bbc9b386731dca1d405fb56b77c278a6ed19ac5d
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<UserDTO>(service.Save(mapper.Map<User>(value))));
        }
    }
}
