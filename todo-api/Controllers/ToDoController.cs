using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_api.Data;
using todo_api.Models;

namespace todo_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext context;
        public ToDoController(ToDoContext context)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo(ToDoRequest toDoRequest)
        {
            var toDo = new ToDo()
            {
                Title = toDoRequest.Title,
                Editing = false,
                Completed = false
            };
            context.ToDos.Add(toDo);
            await context.SaveChangesAsync();
            return Created("CreateToDo", toDo);
        }

        [HttpGet]
        public async Task<IActionResult> GetToDos()
        {
            var toDos = await context.ToDos.ToListAsync();
            return Ok(toDos);
        }
    }
}