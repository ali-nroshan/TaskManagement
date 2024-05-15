using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTOs.Projects;
using TaskManagement.Application.Features.Projects.Requests.Commands;
using TaskManagement.Application.Features.Projects.Requests.Queries;

namespace TaskManagement.WebAPI.Controllers;

public class ProjectsController(IMediator mediator) : ApiBase
{
    [HttpGet("GetUserProjects")]
    public async Task<IActionResult> GetUserProjects([FromQuery] int userId)
    {
        var response = await mediator.Send(new GetProjectsQuery(userId));
        return response.Match(Ok, HandleProblems);
    }

    [HttpPost("CreateNewProject")]
    public async Task<IActionResult> CreateNewProject([FromBody] CreateProjectDto createProjectDto)
    {
        var response = await mediator.Send(new CreateProjectCommand(createProjectDto));
        return response.Match(Ok, HandleProblems);
    }

    [HttpDelete("DeleteProject")]
    public async Task<IActionResult> DeleteProject([FromQuery] int projectId)
    {
        var response = await mediator.Send(new DeleteProjectCommand(projectId));
        return response.Match(s => Ok(), HandleProblems);
    }

    [HttpPut("UpdateProject")]
    public async Task<IActionResult> UpdateProject([FromBody] ProjectDto projectDto)
    {
        var response = await mediator.Send(new UpdateProjectCommand(projectDto));
        return response.Match(Ok, HandleProblems);
    }
}