using TaskTracker.Models;
using Task = TaskTracker.Models.Task;

namespace TaskTracker.Interfaces
{
    public interface ITaskRepository
    {
        Task GetTask(int taskId);
        ICollection<Task> GetTasksOfProject(int projectId);
        bool CreateTask(Project project, TempTask task);
        bool UpdateTask(int taskId, TempTask task);
        bool DeleteTask(Task task);
        bool Save();
    }
}
