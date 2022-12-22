using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public Project Project { get; set; }
    }

    public class TempTask
    {
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }

    public enum TaskStatus
    {
        ToDo, InProgress, Done
    }
}
