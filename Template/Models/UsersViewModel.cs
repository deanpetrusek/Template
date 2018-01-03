using System;
using System.Collections.Generic;
using Template.Core.Domain.Entities;

namespace Template.Models
{
    public class UsersViewModel
    {
        public UsersViewModel()
        {
        }

        public IEnumerable<User> Users { get; set; }
    }
}
