using TaskTracker.Data;
using TaskTracker.Interfaces;
using TaskTracker.Models;

namespace TaskTracker.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext dataContext;

        public ProjectRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Project GetProject(int projectId)
        {
            return dataContext.Projects.Where(p => p.Id == projectId).FirstOrDefault();
        }

        public ICollection<Project> GetProjects()
        {
            return dataContext.Projects.OrderBy(p => p.Id).ToList();
        }

        public bool CreateProject(TempProject project)
        {
            Project newProject = new Project
            {
                Name = project.Name,
                StartDate = project.StartDate,
                CompletionDate = project.CompletionDate,
                Status = project.Status,
                Priority = project.Priority
            };

            dataContext.Add(newProject);

            return Save();
        }

        public bool UpdateProject(int projectId, TempProject project)
        {

            Project newProject = GetProject(projectId);

            newProject.Id = projectId;
            newProject.Name = project.Name;
            newProject.StartDate = project.StartDate;
            newProject.CompletionDate = project.CompletionDate;
            newProject.Status = project.Status;
            newProject.Priority = project.Priority;

            dataContext.Update(newProject);

            return Save();
        }

        public bool DeleteProject(Project project)
        {
            dataContext.Remove(project);

            return Save();
        }

        public bool Save()
        {
            int saved = dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
