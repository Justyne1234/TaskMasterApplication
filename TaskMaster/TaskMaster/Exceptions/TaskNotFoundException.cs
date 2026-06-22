namespace TaskMaster.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException(int id)
            : base($"Task {id} was not found.") { }
    }
}
