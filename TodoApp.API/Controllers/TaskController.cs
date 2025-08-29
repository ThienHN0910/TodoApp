using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.DTOs;
using TodoApp.Application.Interfaces;
using TodoApp.Domain.Entities;

namespace TodoApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TaskController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("getTasks")]
        public async Task<ActionResult<List<Todo>>> GetAllTask()
        {
            var allTask = await _todoService.GetAllTask();
            return Ok(allTask);
        }

        [HttpGet("getTask/{id}")]
        public async Task<ActionResult<Todo>> GetTask(int id)
        {
            var todo = await _todoService.GetTaskById(id);
            return Ok(todo);
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(Todo todo)
        {
            await _todoService.CreateTask(todo);
            return Ok();
        }


        [HttpPatch("{id}/status")]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var ok = await _todoService.ToggleStatusAsync(id);
            return ok ? NoContent() : NotFound();
        }

        // DELETE /api/tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _todoService.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }


    }
}
