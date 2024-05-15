namespace TaskManagement.Domain.Entities;

public class TaskModel
{
    public int TaskId { get; init; }
    public required string TaskName { get; set; }

    //relations
    public required int ProjectId { get; set; }
    public required ProjectModel Project { get; init; }
}