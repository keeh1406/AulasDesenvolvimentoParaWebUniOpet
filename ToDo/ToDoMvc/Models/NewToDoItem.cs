using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoMvc.Models
{
    public class NewToDoItem
        {
            [Required]
            public string Title {get; set;}

            public DateTimeOffset? DueAt {get; set;}
        }
}