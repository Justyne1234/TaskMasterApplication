using Microsoft.EntityFrameworkCore;
using TaskMaster.DbContexts;
using TaskMaster.Models;

namespace TaskMaster.Repositories
{
    public class TaskRepositorySqlProc : ITaskRepository
    {
        private readonly AppDbContext _dbContext;
        public TaskRepositorySqlProc(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateTask(TaskItem task)
        {
            await _dbContext.Database
            .ExecuteSqlInterpolatedAsync($@"
                CALL CreateTask(
                    {task.OwnerId},
                    {task.Title},
                    {task.Description},
                    {task.DueDate},
                    {task.Category},
                    {task.Priority},
                    {task.Status}
                )");

            return task.Id;
        }
        public async Task<List<TaskItem>> GetAllTasksByOwnerId(int ownerId)
        {
            var tasks = await _dbContext.Tasks
                .FromSqlInterpolated($"CALL GetAllTasksByOwnerId({ownerId})")
                .ToListAsync();
            return tasks;
        }

        public async Task<TaskItem?> UpdateTask(TaskItem task)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                    $"CALL UpdateTask({task.Id}, {task.Title}, {task.Description}, {task.DueDate}, {task.Category}, {task.Priority}, {task.Status})"
                );

            return task;
        }
        public async Task<bool> DeleteTask(TaskItem task)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($"CALL DeleteTask({task.Id})");
            return true;
        }

        public async Task<TaskItem?> GetTaskById(int id)
        {
            var task = await _dbContext.Tasks
                .FromSqlInterpolated($"CALL GetTaskById({id})")
                .ToListAsync();
            return task.FirstOrDefault();
        }
    }
}
