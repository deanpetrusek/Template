// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Template.API.Controllers
{
    public class UserDto
    {
        public UserDto(){}

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        public UserDto(Core.Domain.Entities.User user)
        {
            this.FirstName = user.FirstName;
            this.Id = user.Id;
            this.LastName = user.LastName;
        }
    }
}
