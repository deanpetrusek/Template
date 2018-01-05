using System;
using MediatR;

namespace Template.Core.Domain.Events.Users
{
    public class Updated: INotification
    {
        public Entities.User User { get; }

        public Updated(Entities.User user)
        {
            User = user;
        }
    }
}
