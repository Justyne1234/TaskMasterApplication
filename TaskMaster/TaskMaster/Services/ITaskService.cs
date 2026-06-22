using TaskMaster.Models;
using TaskMaster.Models.Requests;
using TaskMaster.Models.Responses;

namespace TaskMaster.Services
{
    public interface ITaskService
    {
        public Task<int> CreateTask(TaskRequest task);
        public Task<List<TaskResponse>> GetAllOwnerTasks(int id);
        public Task<TaskResponse> UpdateTask(TaskRequest task);
        public Task<bool> DeleteTask(int id);
        public Task<TaskItem?> GetTaskById(int id);
    }
}
