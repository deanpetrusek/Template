using System;
using System.Collections.Generic;
using MediatR;

namespace Template.Core.Domain.UserActions
{
    public class UsersQuery : IRequest<IEnumerable<Entities.User>>
    {
    }

    public class UserQuery: IRequest<Entities.User>
    {
        public int Id { get; }

        public UserQuery(int id){
            Id = id;
        }
    }
}
