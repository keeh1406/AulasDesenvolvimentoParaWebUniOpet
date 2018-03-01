using System.Collections.Generic;

namespace ToDoMvc.Models.View
{
    public class ToDoViewModel
    {
        public IEnumerable<ToDoItem> Items {get;set;}
        
    }
}