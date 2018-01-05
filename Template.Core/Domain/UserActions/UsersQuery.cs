using System.Collections.Generic;
using MediatR;

namespace Template.Core.Domain.UserActions
{
    public class UsersQuery : IRequest<IEnumerable<Entities.User>>
    {
    }
}
