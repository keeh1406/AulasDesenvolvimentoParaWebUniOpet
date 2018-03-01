using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoMvc.Models;

namespace ToDoMvc.Services
{
    public class FakeToDoItemService : ITodoItemService
    {
        public Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync()
        {
            IEnumerable<ToDoItem> items = new []
            {
                new ToDoItem
                {
                    Title = "Learn ASP.NET Core",
                    DueAt = DateTimeOffset.Now.AddDays(1)
                },

                new ToDoItem
                {
                    Title = "Build Awsome apps",
                    DueAt = DateTimeOffset.Now.AddDays(2)
                }
            };

            return Task.FromResult(items);
        }
    };
}