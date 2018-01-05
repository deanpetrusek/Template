using System;
using MediatR;

namespace Template.Core.Domain.Events.Users
{
    public class Added : INotification 
    {
        public Entities.User User { get; }

        public Added(Entities.User user)
        {
            User = user;
        }
    }
}
