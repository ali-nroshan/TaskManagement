using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiBase : ControllerBase
{
    protected IActionResult HandleProblems(List<Error> errors)
    {
        var first = errors[0];

        var statusCode = first.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: first.Description);
    }
}