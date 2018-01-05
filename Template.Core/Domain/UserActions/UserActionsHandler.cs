using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Template.Core.Domain.Entities;

namespace Template.Core.Domain.UserActions
{
    public class UserActionsHandler :
    IRequestHandler<UsersQuery, IEnumerable<Entities.User>>,
    IRequestHandler<AddUser>,
    IRequestHandler<UserQuery, Entities.User>,
    IRequestHandler<DeleteUser>,
    IRequestHandler<UpdateUser>
    {
        public IMediator Mediator { get; }
        public TemplateContext AggregateRoot { get; }

        public UserActionsHandler(IMediator mediator, TemplateContext aggregateRoot)
        {
            AggregateRoot = aggregateRoot;
            Mediator = mediator;
        }

        public Task<IEnumerable<User>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(AggregateRoot.GetAllUsers());
        }

        public async Task Handle(AddUser command, CancellationToken cancellationToken)
        {
            await AggregateRoot.AddUser(command.FirstName, command.LastName);
        }

        public async Task<User> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            return AggregateRoot.GetUser(request.Id);
        }

        public async Task Handle(UpdateUser message, CancellationToken cancellationToken)
        {
            await AggregateRoot.UpdateUser(message.Id, message.FirstName, message.LastName);
        }

        public async Task Handle(DeleteUser message, CancellationToken cancellationToken)
        {
            await AggregateRoot.DeleteUser(message.Id);
        }
    }
}
