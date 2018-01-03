using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Template.API.Controllers
{

    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        public UserDto(Core.Domain.Entities.User user) {
            this.FirstName = user.FirstName;
            this.Id = user.Id;
            this.LastName = user.LastName;
        }
    }

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
        public async void Post([FromBody]UserDto user)
        {
            await Mediator.Send(new Core.Domain.UserActions.AddUser(user.FirstName, user.LastName));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]UserDto user)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
