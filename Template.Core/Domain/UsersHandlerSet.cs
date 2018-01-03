using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Template.Core.Domain.Entities;
using Template.Data;

namespace Template.Core.Domain
{
    public class UsersQuery: IRequest<IEnumerable<User>>{
        
    }

    public class AddUser: IRequest {
        public string FirstName { get; }
        public string LastName { get; }

        public AddUser(string firstName, string lastName){
            LastName = lastName;
            FirstName = firstName;
        }
    }

    public class UsersHandler: 
        IRequestHandler<UsersQuery, IEnumerable<User>>,
        IRequestHandler<AddUser>
    {
        public IMediator Mediator { get; }

        public UsersHandler(IMediator mediator)
        {
            Mediator = mediator;
        }

        public async Task<IEnumerable<User>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            var userPocos = await Mediator.Send(new Data.UsersQuery());
            return userPocos.Select(x => new User(x.UserId, x.FirstName, x.LastName));
        }

        public async Task Handle(AddUser notification, CancellationToken cancellationToken)
        {
            var user = await Mediator.Send(new Data.AddUser(notification.FirstName, notification.LastName));
        }
    }
}
