using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoMvc.Data;
using TodoMvc.Models;
using TodoMvc.Services;
using Xunit;

namespace AspNetCoreTodo.UnitTests
{
    public class TodoItemServiceShould
    {
        [Fact]
        public async Task AddNewItemAsIncompleteWithDueDate()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
     .UseInMemoryDatabase(databaseName: "Test_AddNewItem").Options;

            // Set up a context (connection to the "DB") for writing
            using (var context = new ApplicationDbContext(options))
            {
                var service = new ToDoItemService(context);

                var fakeUser = new ApplicationUser
                {
                    Id = "fake-000",
                    UserName = "fake@example.com"
                };

                await service.AddItemAsync(new NewToDoItem
                {
                    Title = "Testing?"
                }, fakeUser);
            }
        }
    }
}
