using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoMvc.Models;
using ToDoMvc.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoMvc.Services
{
    public class ToDoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

public ToDoItemService(ApplicationDbContext context)
{
    _context = context;
}
        public async Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync()
        {
            var items = await _context.Items.Where(x =>x.IsDone == false).ToArrayAsync();
            return items;
        }
    }
}