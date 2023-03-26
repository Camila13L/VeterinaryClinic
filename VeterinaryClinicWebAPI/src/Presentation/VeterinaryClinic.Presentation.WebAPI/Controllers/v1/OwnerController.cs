using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Core.Application.Features.Owners.Commands.CreateOwnerCommand;
using VeterinaryClinic.Core.Application.Features.Owners.Commands.DeleteOwnerCommand;
using VeterinaryClinic.Core.Application.Features.Owners.Commands.UpdateOwnerCommand;
using VeterinaryClinic.Core.Application.Features.Owners.Queries.GetAllOwners;
using VeterinaryClinic.Core.Application.Features.Owners.Queries.GetOwnerbyId;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VeterinaryClinic.Presentation.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OwnerController : BaseApiController
    {
        // POST api/owner controller
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CreateOwnerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        //PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, UpdateOwnerCommand command)
        {
            if (id != command.Id) return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok(await Mediator.Send(new DeleteOwnerCommand { Id = id }));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetOwnerByIdQuery { Id = id }));
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllOwnersParameters filter)
        {

            return Ok(await Mediator.Send(new GetAllOwnersQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                FullName = filter.FullName,
            }));
        }
    }
}

