using System.Collections.Generic;
using MediatR;
using Template.Data.POCOs;

namespace Template.Data
{
    public class UsersQuery : IRequest<IEnumerable<User>>
    {
        public UsersQuery()
        {
        }
    }
}
