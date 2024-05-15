using ErrorOr;

namespace TaskManagement.Domain.Common.Errors;

public static partial class Errors
{
    public static class Project
    {
        public static Error ProjectNotFound => Error.NotFound("Project.NotFound");
        public static Error DuplicateProject => Error.Conflict("Project.Duplicate");
    }
}