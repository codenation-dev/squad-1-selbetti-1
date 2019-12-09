using AutoMapper;
using CentralErros.Models;
using CentralErros.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;

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

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("{login,password}")]
        public HttpResponseMessage ValidateLogin()
        {
            CentralErrosContext context = new CentralErrosContext(new Microsoft.EntityFrameworkCore.DbContextOptions<CentralErrosContext>());
            UserService userService = new UserService(context);
            User user = new User();
            string email = HttpContext.Request.Headers["login"];
            string password = HttpContext.Request.Headers["password"];

            user = userService.GetByEmail(email);

            if (user != null && user.Password == password)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Email, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                });

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {


                });

                //return Request.CreateResponse(HttpStatusCode.OK, new { token = securityToken);
            }

            //return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }
}
