using System;
namespace Template.Core.Domain.Entities
{
    public class User
    {
        public User(string firstName, string lastName, int? id = null)
        {
            FirstName = firstName;
            LastName = lastName;

            if (id.HasValue)
                Id = id.Value;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Id { get; set; }

        public void ChangeName(string firstName, string lastName){
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
