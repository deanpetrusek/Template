using System;
using MediatR;

namespace Template.Core.Domain.Events.Users
{
    public class Deleted: INotification
    {
        public Entities.User User { get; }

        public Deleted(Entities.User user)
        {
            User = user;
        }
    }
}
