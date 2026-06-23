using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Models.Requests;
public class RegistrationRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public string GoogleId { get; set; }
    public string AuthenticationMethod { get; set; }
}