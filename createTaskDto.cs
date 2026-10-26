// DTO para recibir la nueva tarea del cliente
namespace MiProyectoApi.DTOs
{
    public class CreateTaskDto
    {
    public string? Title { get; set; }
    public string? Description { get; set; }
    }
}