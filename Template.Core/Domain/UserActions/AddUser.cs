using System;
using MediatR;

namespace Template.Core.Domain.UserActions
{
    public class AddUser : IRequest
    {
        public string FirstName { get; }
        public string LastName { get; }

        public AddUser(string firstName, string lastName)
        {
            LastName = lastName;
            FirstName = firstName;
        }
    }
}