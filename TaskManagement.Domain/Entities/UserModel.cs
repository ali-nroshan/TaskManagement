namespace TaskManagement.Domain.Entities;

public class UserModel
{
    public int UserId { get; init; }
    public required string Username { get; set; }

    //relations
    public ICollection<ProjectModel>? UserProjects { get; init; }
}