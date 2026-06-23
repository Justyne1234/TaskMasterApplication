namespace TaskMaster.Models.Requests;
public class RegistrationRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string GoogleId { get; set; }
    public string AuthenticationMethod { get; set; }
}