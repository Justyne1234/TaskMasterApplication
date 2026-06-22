using TaskMaster.Models;
using TaskMaster.Models.Requests;
using TaskMaster.Models.Responses;

namespace TaskMaster.Repositories
{
    public interface ITaskRepository
    {
        public Task<int> CreateTask(TaskItem task);
        public Task<List<TaskResponse>> GetAllTasksByOwnerId(int id);
        public Task<TaskItem?> UpdateTask(TaskItem task);
        public Task<bool> DeleteTask(TaskItem task);
        public Task<TaskItem?> GetTaskById(int id);
    }
}
