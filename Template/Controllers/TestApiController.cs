using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Core.Domain;
using Jil;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Template.Controllers
{
    public class UserDto{
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    [Route("api/[controller]")]
    public class TestApiController : Controller
    {
        public IMediator Mediator { get; }

        public TestApiController(IMediator mediator){
            Mediator = mediator;
        }
        // GET: api/values
        [HttpGet]
        public async System.Threading.Tasks.Task<IEnumerable<string>> Get()
        {
            var users = await Mediator.Send(new UsersQuery());
            return users.Select(x => JSON.Serialize(x));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]UserDto user)
        {
            Mediator.Send(new AddUser(user.FirstName, user.LastName));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
