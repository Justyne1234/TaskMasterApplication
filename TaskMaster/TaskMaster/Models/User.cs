using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Models;
public class User
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    public string? Password { get; set; }
    public string? GoogleId { get; set; }
    [Required]
    public string AuthenticationMethod { get; set; }

    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}