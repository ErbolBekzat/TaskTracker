using TaskTracker.Models;

namespace TaskTracker.Interfaces
{
    public interface IProjectRepository
    {
        ICollection<Project> GetProjects();

        Project GetProject(int projectId);
        bool CreateProject(TempProject project);
        bool UpdateProject(int projectId, TempProject project);
        bool DeleteProject(Project project);
        bool Save();
    }
}
