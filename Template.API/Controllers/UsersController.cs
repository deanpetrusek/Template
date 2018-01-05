using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        public IMediator Mediator { get; }

        public UsersController(IMediator mediator){
            Mediator = mediator;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            var users = await Mediator.Send(new Core.Domain.UserActions.UsersQuery());
            return users.Select(x => new UserDto(x));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            var user = await Mediator.Send(new Core.Domain.UserActions.UserQuery(id));
            return new UserDto(user);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserDto user)
        {
            if (user == null)
                return BadRequest();
            
            await Mediator.Send(new Core.Domain.UserActions.AddUser(user.FirstName, user.LastName));
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UserDto user)
        {
            await Mediator.Send(new Core.Domain.UserActions.UpdateUser(id, user.FirstName, user.LastName));
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new Core.Domain.UserActions.DeleteUser(id));
            return Ok();
        }
    }
}
