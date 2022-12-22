using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }

    public class TempProject
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
    }

    public enum ProjectStatus
    {
        NotStarted, Active, Completed
    }
}
