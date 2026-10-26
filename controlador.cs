using Microsoft.AspNetCore.Mvc;
using MiProyectoApi.Models;
using MiProyectoApi.DTOs;

namespace MiProyectoApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        // Simulamos una base de datos en memoria
        private static readonly List<TaskItem> _tasks = new();
        private static int _nextId = 1;

        // GET: api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<TaskResponseDto>> GetTasks()
        {
            var responseList = _tasks.Select(t => new TaskResponseDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted
            });

            return Ok(responseList);
        }

        // POST: api/tasks
        [HttpPost]
        public ActionResult<TaskResponseDto> CreateTask([FromBody] CreateTaskDto newTaskDto)
        {
            // 1. Creamos la entidad interna con los datos recibidos
            var task = new TaskItem
            {
                Id = _nextId++,
                Title = newTaskDto.Title,
                Description = newTaskDto.Description,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow // No viaja al cliente
            };

            _tasks.Add(task);

            // 2. Mapeamos la entidad al DTO de respuesta seguro
            var responseDto = new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted
            };

            // 3. Devolvemos la respuesta
            return Ok(responseDto);
        }
    }
}