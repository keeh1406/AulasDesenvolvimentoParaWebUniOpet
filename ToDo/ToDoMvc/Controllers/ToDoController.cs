using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoMvc.Services;
using ToDoMvc.Models.View;
using ToDoMvc.Models;

namespace ToDoMvc.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoItemService _todoItemsService;

        public ToDoController(ITodoItemService todoItemsService)
        {
            _todoItemsService = todoItemsService;
        }

        public async Task<IActionResult> Index()
        {
            //Acessar os dados
            var todoItems = await _todoItemsService.GetIncompleteItemsAsync();
            //Montar uma model
            var viewModel = new ToDoViewModel
            {
                Items = todoItems
            };
            //Retornar a view
            return View(viewModel);
        }

        public async Task<IActionResult> AddItem(NewToDoItem newToDoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var successful = await _todoItemsService.AddItemAsync(newToDoItem);

            if (!successful)
            {
                return BadRequest(new { Error = "Could not add item" });
            }

            return Ok();
        }
        public async Task<IActionResult> MarkDoneAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var successful = await _todoItemsService.MarkDoneAsync(id);
            return Ok();
        }
    }
}