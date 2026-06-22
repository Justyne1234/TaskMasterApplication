using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Models.Requests;
public class GoogleLoginRequest
{
    [Required]
    public string googleToken { get; set; }
}