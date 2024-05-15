namespace TaskManagement.Domain.Entities;

public class ProjectModel
{
    public int ProjectId { get; init; }
    public required string ProjectName { get; set; }

    //relations
    public int UserId { get; init; }
    public required UserModel User { get; init; }
    public ICollection<TaskModel>? ProjectTasks { get; init; }
}