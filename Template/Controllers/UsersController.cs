using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Core.Domain;
using Template.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Template.Controllers
{
    public class UsersController : Controller
    {
        public IMediator Mediator { get; }

        public UsersController(IMediator mediator)
        {
            Mediator = mediator;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var users = await Mediator.Send(new UsersQuery());
            var viewModel = new UsersViewModel{
                Users = users
            };
            return View(viewModel);
        }
    }
}
