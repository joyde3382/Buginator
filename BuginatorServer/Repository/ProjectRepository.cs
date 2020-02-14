using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        RepositoryContext _dbContext;
        public ProjectRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _dbContext = repositoryContext;
        }
        public IEnumerable<Project> ProjectsByUser(Guid userId)
        {
            var results = (from project in _dbContext.Project
                          where project.UserHasProject.Any(p => p.UserUserId.Equals(userId))
                          select project).ToList();

            return results;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return FindAll()
                .OrderBy(ow => ow.Title)
                .ToList();
        }

        public Project GetProjectById(Guid projectId)
        {
            return FindByCondition(project => project.ProjectId.Equals(projectId))
                    .FirstOrDefault();
        }

        public Project GetProjectWithDetails(Guid projectId)
        {
            return FindByCondition(project => project.ProjectId.Equals(projectId))
                .Include(ac => ac.UserHasProject)
                    .ThenInclude(userHasProject => userHasProject.UserUser)
                .Include(project => project.Ticket)
                    //.ThenInclude(ticket => ticket.ProjectProjectId.Equals(projectId))
                .FirstOrDefault();

            //return null;
        }

        public void CreateProject(Project project)
        {
            Create(project);
        }
        public void UpdateProject(Project user)
        {
            Update(user);
        }
        public void DeleteProject(Project project)
        {
            Delete(project);
        }
    }
}