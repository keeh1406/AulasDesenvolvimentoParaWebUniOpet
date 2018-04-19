using System.Collections.Generic;

namespace TodoMvc.Models.View
{
    public class ToDoViewModel
    {
        public IEnumerable<ToDoItem> Items { get; set; }
    }
}