using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskMaster.DbContexts;
using TaskMaster.Models;
using TaskMaster.Models.Enums;
using TaskMaster.Models.Requests;
using TaskMaster.Models.Responses;

namespace TaskMaster.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _dbContext;
        public TaskRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateTask(TaskItem task)
        {
            _dbContext.Add(task);
            await _dbContext.SaveChangesAsync();
            return task.Id;
        }
        public async Task<List<TaskResponse>> GetAllTasksByOwnerId(int ownerId)
        {
            var tasks = await _dbContext.Tasks
                .Where(x => x.OwnerId == ownerId)
                .Select(x => new TaskResponse
                {
                    Id = x.Id,
                    OwnerId = x.OwnerId,
                    Title = x.Title,
                    Description = x.Description,
                    DueDate = x.DueDate,
                    Category = x.Category,
                    Priority = x.Priority,
                    Status = x.Status
                })
                .ToListAsync();
            return tasks;
        }

        public async Task<TaskItem?> UpdateTask(TaskItem task)
        {
            _dbContext.Update(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }
        public async Task<bool> DeleteTask(TaskItem task)
        {
            _dbContext.Remove(task);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TaskItem?> GetTaskById(int id)
        {
            return await _dbContext.Tasks
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
