using Microsoft.EntityFrameworkCore;

namespace todo_api.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}