using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuginatorServer.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ProjectController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                var projects = _repository.Project.GetAllProjects();

                _logger.LogInfo($"Returned all projects from database.");

                var projectsResult = _mapper.Map<IEnumerable<ProjectDto>>(projects);
                return Ok(projectsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllProjects action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ProjectById")]
        public IActionResult GetProjectById(Guid id)
        {
            try
            {
                var project = _repository.Project.GetProjectById(id);

                if (project == null)
                {
                    _logger.LogError($"Project with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned project with id: {id}");

                    var projectResult = _mapper.Map<ProjectDto>(project);
                    return Ok(projectResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProjectById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/project")]
        public IActionResult GetProjectWithDetails(Guid id)
        {
            try
            {
                var project = _repository.Project.GetProjectWithDetails(id);

                if (project == null)
                {
                    _logger.LogError($"Project with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned project with details for id: {id}");

                    var projectResult = _mapper.Map<ProjectDto>(project);
                    return Ok(projectResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProjectWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody]ProjectForCreationDto project)
        {
            try
            {
                if (project == null)
                {
                    _logger.LogError("Project object sent from client is null.");
                    return BadRequest("Project object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid project object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var projectEntity = _mapper.Map<Project>(project);

                _repository.Project.CreateProject(projectEntity);
                _repository.Save();

                var createdProject = _mapper.Map<ProjectDto>(projectEntity);

                return CreatedAtRoute("ProjectById", new { id = createdProject.ProjectId }, createdProject);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProject action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(Guid id, [FromBody]ProjectForUpdateDto project)
        {
            try
            {
                if (project == null)
                {
                    _logger.LogError("Project object sent from client is null.");
                    return BadRequest("Project object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid project object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var projectEntity = _repository.Project.GetProjectById(id);
                if (projectEntity == null)
                {
                    _logger.LogError($"Project with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(project, projectEntity);

                _repository.Project.UpdateProject(projectEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProject action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(Guid id)
        {
            try
            {
                var project = _repository.Project.GetProjectById(id);

                if (project == null) // .IsEmptyObject()
                {
                    _logger.LogError($"Project with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                //if (_repository.Project.ProjectsByProject(id).Any())
                //{
                //    _logger.LogError($"Cannot delete project with id: {id}. It has related projects. Delete those projects first");
                //    return BadRequest("Cannot delete project. It has related projects. Delete those projects first");
                //}

                _repository.Project.DeleteProject(project);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteProject action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}