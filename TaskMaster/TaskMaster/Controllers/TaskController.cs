using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskMaster.Exceptions;
using TaskMaster.Models.Requests;
using TaskMaster.Services;

namespace TaskMaster.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskController : Controller
{
    ITaskService _taskService;
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _taskService.GetTaskById(id);
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskRequest request)
    {
        var id = await _taskService.CreateTask(request);
        return StatusCode(StatusCodes.Status201Created, id);
    }

    [HttpGet]
    public async Task<IActionResult> GetTasksByOwnerId([FromQuery] int ownerId)
    {
        var tasks = await _taskService.GetAllOwnerTasks(ownerId);
        return Ok(tasks);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTask([FromBody] TaskRequest request)
    {
        var task = await _taskService.UpdateTask(request);
        return Ok(task);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var result = await _taskService.DeleteTask(id);
        return Ok(result);
    }
}