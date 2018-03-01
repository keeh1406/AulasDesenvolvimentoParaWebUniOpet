using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoMvc.Services;
using ToDoMvc.Models.View;

namespace ToDoMvc.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoItemService _todoItemsService;

        public  ToDoController(ITodoItemService todoItemsService)
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
    }
}