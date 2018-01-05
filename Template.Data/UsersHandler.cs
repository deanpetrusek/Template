using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Template.Data.POCOs;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Template.Core.Domain.Events.Users;

namespace Template.Data
{
    public class UsersHandler : 
    INotificationHandler<Core.Domain.Events.Users.Added>,
    INotificationHandler<Core.Domain.Events.Users.Deleted>,
    INotificationHandler<Core.Domain.Events.Users.Updated>,
    IRequestHandler<UsersQuery, IEnumerable<User>>
    {
        public Context Context { get; }

        public UsersHandler(Context context){
            Context = context;
        }

        private Task<User> GetUser(IDbConnection db, int id){
            return db.QuerySingleAsync<User>("SELECT * FROM domain.Users WHERE UsersId = @id", new { id = id});
        }

        private Task<IEnumerable<User>> GetAllUsers(IDbConnection db)
        {
            return db.QueryAsync<User>("SELECT * FROM domain.Users");
        }

        private Task<int> DeleteUser(IDbConnection db, int id){
            return db.ExecuteAsync("DELETE FROM domain.Users WHERE UsersId = @id", new { id = id });
        }

        private Task<int> InsertUser(IDbConnection db, string firstName, string lastName){
            return db.ExecuteAsync(
                "INSERT domain.users(FirstName, LastName) VALUES (@FirstName, @LastName)", 
                new { FirstName = firstName, LastName = lastName });
        }

        private Task<int> UpdateUser(IDbConnection db, int id, string firstName, string lastName){
            return db.ExecuteAsync(
                "UPDATE domain.users SET FirstName = @firstName, LastName = @lastName WHERE UsersId = @id", 
                new { firstName = firstName, lastName = lastName, id = id });
        }

        private async Task Execute(Func<IDbConnection, Task> func)
        {
            var connectionString = Context.ConnectionString;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                await func(db);
            }
        }

        public async Task Handle(Added addedEvent, CancellationToken cancellationToken)
        {
            await Execute(async db =>
            {
                var id = await InsertUser(db, addedEvent.User.FirstName, addedEvent.User.LastName);
                addedEvent.User.Id = id;
            });
        }

        public async Task Handle(Deleted notification, CancellationToken cancellationToken)
        {
            await Execute(async db =>
            {
                await DeleteUser(db, notification.User.Id);
            });
        }

        public async Task Handle(Updated updatedEvent, CancellationToken cancellationToken)
        {
            var user = updatedEvent.User;
            await Execute(async db =>
            {
                await UpdateUser(db, user.Id, user.FirstName, user.LastName);
            });
        }

        public async Task<IEnumerable<User>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User> users = null;
            await Execute(async db => {
                users = await GetAllUsers(db);
            });
            return users;
        }
    }
}
