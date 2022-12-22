using Microsoft.AspNetCore.Mvc;
using TaskTracker.Interfaces;
using TaskTracker.Models;
using Task = TaskTracker.Models.Task;

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskRepository taskRepository;
        private readonly IProjectRepository projectRepository;

        public TaskController(ITaskRepository taskRepository, IProjectRepository projectRepository)
        {
            this.taskRepository = taskRepository;
            this.projectRepository = projectRepository;
        }

        [HttpGet("projectTasks/{projectId}")]
        public IActionResult GetTasksOfProject(int projectId)
        {
            ICollection<Task> tasks = taskRepository.GetTasksOfProject(projectId);

            if (!ModelState.IsValid) return BadRequest();

            return Ok(tasks);
        }

        [HttpGet("task/{taskId}")]
        public IActionResult GetTask(int taskId)
        {
            Task task = taskRepository.GetTask(taskId);

            if (task == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask([FromQuery] int projectId, [FromBody] TempTask task)
        {
            Project project = projectRepository.GetProject(projectId);

            if (project == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            if (!taskRepository.CreateTask(project, task))
            {
                ModelState.AddModelError("", "Something went wrong while creating");
                return StatusCode(500, ModelState);
            }

            return Ok(task);
        }

        [HttpPut("{taskId}")]
        public IActionResult UpdateTask(int taskId, [FromBody] TempTask task)
        {
            Task findTask = taskRepository.GetTask(taskId);

            if (findTask == null) return NotFound(); 

            if (!ModelState.IsValid) return BadRequest();

            if (!taskRepository.UpdateTask(taskId, task))
            {
                ModelState.AddModelError("", "Something went wrong while editing");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{taskId}")]
        public IActionResult DeleteTask(int taskId)
        {
            Task task = taskRepository.GetTask(taskId);

            if (task == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            if (!taskRepository.DeleteTask(task))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
