using TaskTracker.Data;
using TaskTracker.Interfaces;
using TaskTracker.Models;
using Task = TaskTracker.Models.Task;

namespace TaskTracker.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext dataContext;

        public TaskRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Task GetTask(int taskId)
        {
            return dataContext.Tasks.Where(t => t.Id == taskId).FirstOrDefault();
        }

        public ICollection<Task> GetTasksOfProject(int projectId)
        {
            return dataContext.Tasks.Where(t => t.Project.Id == projectId).OrderBy(t => t.Id).ToList();
        }

        public bool CreateTask(Project project, TempTask task)
        {
            Task newTask = new Task
            {
                Name = task.Name,
                Status = task.Status,
                Description = task.Description,
                Priority = task.Priority,
                Project = project
            };

            dataContext.Add(newTask);

            return Save();
        }

        public bool UpdateTask(int taskId, TempTask task)
        {
            Task newTask = GetTask(taskId);

            newTask.Id = taskId;
            newTask.Name = task.Name;
            newTask.Status = task.Status;
            newTask.Description = task.Description;
            newTask.Priority = task.Priority;

            dataContext.Tasks.Update(newTask);

            return Save();
        }

        public bool DeleteTask(Task Task)
        {
            dataContext.Remove(Task);

            return Save();
        }

        public bool Save()
        {
            int saved = dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
