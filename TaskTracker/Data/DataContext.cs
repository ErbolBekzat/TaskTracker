using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;
using Task = TaskTracker.Models.Task;

namespace TaskTracker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
