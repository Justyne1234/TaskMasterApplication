namespace TaskMaster.Exceptions;
public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException(string username)
        : base($"Username '{username}' is already taken") { }
}