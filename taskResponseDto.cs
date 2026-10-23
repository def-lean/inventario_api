// DTO para responderle al cliente (oculta la fecha exacta de creación interna)
public class TaskResponseDto 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}