using AutoMapper;
using CentralErros.DTOs;
using CentralErros.Models;
using CentralErros.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CentralErros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class LogController : ControllerBase
    {
        private ILogService service;
        private readonly IMapper mapper;

        public LogController(ILogService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/Log
        [HttpGet]
        public ActionResult<IEnumerable<LogDTO>> Get(string level = null, string environment = null, string descricao = null, string origem = null)
        {
            if (level != null)
                return Ok(service.FindByLevel(level)
                    .Select(x => mapper.Map<LogDTO>(x))
                    .ToList());
            else if (environment != null)
                return Ok(service.FindByEnvironment(environment)
                    .Select(x => mapper.Map<LogDTO>(x))
                    .ToList());
            else if (descricao != null)
                return Ok(service.FindByDescricao(descricao)
                    .Select(x => mapper.Map<LogDTO>(x))
                    .ToList());
            else if (origem != null)
                return Ok(service.FindByOrigem(origem)
                    .Select(x => mapper.Map<LogDTO>(x))
                    .ToList());
            else
                return Ok(service.GetAll()
                    .Select(x => mapper.Map<LogDTO>(x))
                    .ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<LogDTO> GetSingle(int id)
        {
            return Ok(service.Get(id));
        }


        // POST: api/Log
        [HttpPost]
        public ActionResult<LogDTO> Post([FromBody] LogDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<LogDTO>(service.Save(mapper.Map<Log>(value))));
        }

        // PUT: api/Log/5
        [HttpPut("{id}")]
        public ActionResult<LogDTO> Put(int id)
        {
            return Ok(mapper.Map<LogDTO>(service.Archive(service.Get(id))));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<LogDTO> Delete(int id)
        {
            return Ok(mapper.Map<LogDTO>(service.Delete(service.Get(id))));
        }
    }
}
