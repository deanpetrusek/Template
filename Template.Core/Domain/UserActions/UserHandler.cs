using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Template.Core.Domain.Entities;

namespace Template.Core.Domain.UserActions
{
    public class UsersHandler :
        IRequestHandler<UsersQuery, IEnumerable<Entities.User>>,
        IRequestHandler<AddUser>,
        IRequestHandler<UserQuery, Entities.User>
    {
        public IMediator Mediator { get; }

        public UsersHandler(IMediator mediator)
        {
            Mediator = mediator;
        }

        public async Task<IEnumerable<User>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            var userPocos = await Mediator.Send(new Data.UsersQuery());
            return userPocos.Select(x => new Entities.User(x.UsersId, x.FirstName, x.LastName));
        }

        public async Task Handle(AddUser command, CancellationToken cancellationToken)
        {
            await Mediator.Send(new Data.AddUser(command.FirstName, command.LastName));
        }

        public async Task<User> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var user = await Mediator.Send(new Data.UserQuery(request.Id));
            return new Entities.User(user.UsersId, user.FirstName, user.LastName);
        }
    }
}
