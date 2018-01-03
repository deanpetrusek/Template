using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Template.Data.POCOs;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Template.Data
{
    public class UsersQuery: IRequest<IEnumerable<User>>
    {
    }

    public class AddUser: IRequest<User> {
        public string FirstName { get; }
        public string LastName { get; }

        public AddUser(string firstName, string lastName)
        {
            LastName = lastName;
            FirstName = firstName;
        }
    }

    public class UsersHandler : 
        IRequestHandler<UsersQuery, IEnumerable<User>>, 
        IRequestHandler<AddUser, User>
    {
        public Context Context { get; }

        public UsersHandler(Context context){
            Context = context;
        }

        public async Task<IEnumerable<User>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            var connectionString = Context.ConnectionString;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return await db.QueryAsync<User>("Select * From domain.Users");
            }
        }

        public async Task<User> Handle(AddUser notification, CancellationToken cancellationToken)
        {
            var connectionString = Context.ConnectionString;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var id = await db.ExecuteAsync("INSERT domain.users(FirstName, LastName) VALUES (@FirstName, @LastName)", new { FirstName = notification.FirstName, LastName = notification.LastName });
                return await db.QuerySingleAsync<User>("SELECT * FROM domain.Users WHERE UserID = @id", new { id = id });
            }
        }
    }
}
