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
        try
        {
            var task = await _taskService.GetTaskById(id);
            return Ok(task);
        }
        catch (TaskNotFoundException ex)
        {
            return NotFound(new { message = ex.Message} );
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unexpected error occurred" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskRequest request)
    {
        try
        {
            var id = await _taskService.CreateTask(request);
            return StatusCode(StatusCodes.Status201Created, id);
        }
        catch(ValidationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unexpected error occurred" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetTasksByOwnerId([FromQuery] int ownerId)
    {
        try
        {
            var tasks = await _taskService.GetAllOwnerTasks(ownerId);
            return Ok(tasks);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unexpected error occurred" });
        }
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTask([FromBody] TaskRequest request)
    {
        try
        {
            var task = await _taskService.UpdateTask(request);
            return Ok(task);
        }
        catch (TaskNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unexpected error occurred" });
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        try
        {
            var result = await _taskService.DeleteTask(id);
            return Ok(result);
        }
        catch (TaskNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unexpected error occurred" });
        }
    }
}