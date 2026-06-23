using TaskMaster.Models.Enums;
using TaskMaster.Models;
using TaskMaster.Models.Requests;
using TaskMaster.Models.Responses;
using TaskMaster.Repositories;
using TaskMaster.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Services
{
    public class TaskService : ITaskService
    {
        ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<int> CreateTask(TaskRequest request)
        {
            if (request.DueDate < DateTime.UtcNow.Date)
            {
                throw new ValidationException("Due date cannot be in the past.");
            }
            var task = new TaskItem
            {
                OwnerId = request.OwnerId,
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                Category = request.Category,
                Priority = request.Priority,
                Status = request.Status,
            };
            return await _taskRepository.CreateTask(task);
        }
        public async Task<List<TaskItem>> GetAllOwnerTasks(int id)
        {
            return await _taskRepository.GetAllTasksByOwnerId(id);
        }
        public async Task<TaskResponse?> UpdateTask(TaskRequest request)
        {
            var task = await _taskRepository.GetTaskById(request.Id);

            if (task is null)
            {
                throw new TaskNotFoundException(request.Id);
            }

            task.Title = request.Title;
            task.Description = request.Description;
            task.DueDate = request.DueDate;
            task.Category = request.Category;
            task.Priority = request.Priority;
            task.Status = request.Status;
            
            var updatedTask = await _taskRepository.UpdateTask(task);
            return new TaskResponse
            {
                Id = updatedTask.Id,
                OwnerId = updatedTask.OwnerId,
                Title = updatedTask.Title,
                Description = updatedTask.Description,
                DueDate = updatedTask.DueDate,
                Category = updatedTask.Category,
                Priority = updatedTask.Priority,
                Status = updatedTask.Status
            };
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await GetTaskById(id);
            return await _taskRepository.DeleteTask(task);
        }

        public async Task<TaskItem> GetTaskById(int id)
        {
            var task =  await _taskRepository.GetTaskById(id);
           
            if(task is null)
            {
                throw new TaskNotFoundException(id);
            }
            return task;
        }
    }
}
