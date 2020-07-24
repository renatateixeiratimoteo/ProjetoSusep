using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Susep.Domain.Commands;
using Susep.Domain.Contracts.Repositories;
using Susep.Domain.Entities;
using Susep.Domain.Handler;

namespace Susep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public CommandResult Create([FromBody] ClienteCadastroCommand command, [FromServices] ClienteHandler handler)
        {
            return (CommandResult)handler.Handle(command);
        }


        [Route("")]
        [HttpPut]
        public CommandResult Update([FromBody] ClienteEdicaoCommand command, [FromServices] ClienteHandler handler)
        {
            return (CommandResult)handler.Handle(command);
        }


        [Route("")]
        [HttpGet]
        public IEnumerable<Cliente> Get([FromServices] IClienteRepository repository)
        {
            return repository.FindAll();
        }

        [Route("")]
        [HttpDelete]
        public CommandResult Delete([FromBody] ClienteExclusaoCommand command, [FromServices] ClienteHandler handler)
        {
            return (CommandResult)handler.Handle(command);
        }
    }
}