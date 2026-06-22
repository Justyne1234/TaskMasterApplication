namespace TaskMaster.Exceptions;
public class RegistrationFailedException : Exception
{
    public RegistrationFailedException()
        : base("User registration failed.") { }
}