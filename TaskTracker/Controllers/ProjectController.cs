using Microsoft.AspNetCore.Mvc;
using TaskTracker.Interfaces;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            ICollection<Project> projects = projectRepository.GetProjects();

            if (!ModelState.IsValid) return BadRequest();

            return Ok(projects);
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] TempProject project)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (!projectRepository.CreateProject(project))
            {
                ModelState.AddModelError("", "Something went wrong while creating");
                return StatusCode(500, ModelState);
            }

            return Ok(project);
        }

        [HttpPut("{projectId}")]
        public IActionResult UpdateProject(int projectId, [FromBody] TempProject project)
        {
            Project findProject = projectRepository.GetProject(projectId);

            if (findProject == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            if (!projectRepository.UpdateProject(projectId, project))
            {
                ModelState.AddModelError("", "Something went wrong while editing");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{projectId}")]
        public IActionResult DeleteProject(int projectId)
        {
            Project project = projectRepository.GetProject(projectId);

            if (project == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            if (!projectRepository.DeleteProject(project))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
