using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoMvc.Services;
using TodoMvc.Models.View;
using TodoMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace TodoMvc.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {

        private readonly ITodoItemService _todoItemsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ToDoController(ITodoItemService todoItemsService, UserManager<ApplicationUser> userManager)
        {
            _todoItemsService = todoItemsService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge ();
            };

            // Acessar os dados
            var todoItems = await _todoItemsService.GetIncompleteItemsAsync(currentUser);
            // Montar uma Model
            var viewModel = new ToDoViewModel
            {
                Items = todoItems
            };
            // Retornar View
            return View(viewModel);
        }

        public async Task<IActionResult> AddItem(NewToDoItem newToDoItem)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized();
            };

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var successful = await _todoItemsService.AddItemAsync(newToDoItem, currentUser);

            if (!successful)
                return BadRequest(new { Error = "Could not add Item"});

            return Ok();
        }

        public async Task<IActionResult> MarkDone(Guid id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized();
            };

            if (id == Guid.Empty)
                return BadRequest();

            var successful = await _todoItemsService
                .MarkDoneAsync(id, currentUser);

            return Ok(successful);
        }
    }
}