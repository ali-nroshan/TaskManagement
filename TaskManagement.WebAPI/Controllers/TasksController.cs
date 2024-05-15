using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTOs.Tasks;
using TaskManagement.Application.Features.Tasks.Requests.Commands;
using TaskManagement.Application.Features.Tasks.Requests.Queries;

namespace TaskManagement.WebAPI.Controllers;

public class TasksController(IMediator mediator) : ApiBase
{
    [HttpGet("GetProjectTasks")]
    public async Task<IActionResult> GetProjectTasks([FromQuery] int projectId)
    {
        var response = await mediator.Send(new GetTasksQuery(projectId));
        return response.Match(Ok, HandleProblems);
    }

    [HttpPost("CreateTask")]
    public async Task<IActionResult> CreateNewTask([FromBody] CreateTaskDto createTaskDto)
    {
        var response = await mediator.Send(new CreateTaskCommand(createTaskDto));
        return response.Match(Ok, HandleProblems);
    }

    [HttpPut("UpdateTask")]
    public async Task<IActionResult> UpdateTask([FromBody] TaskDto taskDto)
    {
        var response = await mediator.Send(new UpdateTaskCommand(taskDto));
        return response.Match(Ok, HandleProblems);
    }

    [HttpDelete("DeleteTask")]
    public async Task<IActionResult> DeleteTask([FromQuery] int taskId)
    {
        var response = await mediator.Send(new DeleteTaskCommand(taskId));
        return response.Match(s => Ok(), HandleProblems);
    }
}