using System;
using MediatR;

namespace Template.Core.Domain.UserActions
{
    public class UserQuery : IRequest<Entities.User>
    {
        public int Id { get; }

        public UserQuery(int id)
        {
            Id = id;
        }
    }
}
