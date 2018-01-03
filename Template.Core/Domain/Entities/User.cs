using System;
namespace Template.Core.Domain.Entities
{
    public class User
    {
        public User(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public int Id { get; }
    }
}
