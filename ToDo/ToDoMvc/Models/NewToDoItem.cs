using System;
using System.ComponentModel.DataAnnotations;

namespace TodoMvc.Models
{
    public class NewToDoItem
    {
        [Required]
        public string Title { get; set; }
        
        public DateTimeOffset DueAt { get; set; }
    }
}