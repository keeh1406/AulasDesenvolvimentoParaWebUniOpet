using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoMvc.Models;

namespace TodoMvc.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync(ApplicationUser currentUser);
        Task<bool> AddItemAsync(NewToDoItem newToDoItem, ApplicationUser currentUser);
        Task<bool> MarkDoneAsync(Guid id, ApplicationUser currentUser);
        Task AddItemAsync(NewToDoItem newToDoItem);
        Task AddItemAsync(NewToDoItem newToDoItem, object currentUser);
    }
}