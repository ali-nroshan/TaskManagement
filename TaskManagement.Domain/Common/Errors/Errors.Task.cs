using ErrorOr;

namespace TaskManagement.Domain.Common.Errors;

public static partial class Errors
{
    public static class Task
    {
        public static Error TaskNotFound => Error.NotFound("Task.NotFound");
        public static Error DuplicateTask => Error.Conflict("Task.Duplicate");
    }
}