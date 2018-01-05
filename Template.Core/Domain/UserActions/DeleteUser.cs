using MediatR;

namespace Template.Core.Domain.UserActions
{
    public class DeleteUser : IRequest
    {
        public int Id { get; }

        public DeleteUser(int id)
        {
            Id = id;
        }
    }
}
