using MediatR;

namespace Template.Core.Domain.UserActions
{
    public class UpdateUser : IRequest
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public UpdateUser(int id, string firstName, string lastName)
        {
            LastName = lastName;
            FirstName = firstName;
            Id = id;
        }
    }
}
