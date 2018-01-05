using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Template.Core.Domain.Entities;

namespace Template.Core.Domain
{
    public class TemplateContext
    {
        private IEnumerable<User> _users { get; set; }
        private IMediator _mediator { get; }

        public TemplateContext(IMediator mediator, User[] users)
        {
            _mediator = mediator;
            _users = users;
        }

        public async Task AddUser(string firstName, string lastName)
        {
            var user = new User(firstName, lastName);
            _users.ToList().Add(user);
            await _mediator.Publish(new Events.Users.Added(user));
        }

        public User GetUser(int id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }

        public async Task DeleteUser(int id)
        {
            var userToDelete = _users.SingleOrDefault(x => x.Id == id);
            _users.ToList().Remove(userToDelete);
            await _mediator.Publish(new Events.Users.Deleted(userToDelete));
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public async Task UpdateUser(int id, string firstName, string lastName)
        {
            var user = GetUser(id);
            user.ChangeName(firstName, lastName);
            await _mediator.Publish(new Events.Users.Updated(user));
        }
    }
}
