using TaskMaster.Models.Enums;

namespace TaskMaster.Models.Responses;

public class TaskResponse
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Priority Priority { get; set; }
    public Category Category { get; set; }
    public Status Status { get; set; }
}

