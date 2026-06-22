using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Models;
public class User
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }

    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}