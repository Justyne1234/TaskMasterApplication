using System.ComponentModel.DataAnnotations;
using TaskMaster.Models.Enums;

namespace TaskMaster.Models.Requests;

public class TaskRequest
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    [Required]
    public Priority Priority { get; set; }
    public Category Category { get; set; }
    [Required]
    public Status Status { get; set; }
}

