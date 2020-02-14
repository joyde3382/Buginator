using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IProjectRepository : IRepositoryBase<Project>
    {
        IEnumerable<Project> ProjectsByUser(Guid projectId);
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(Guid projectId);
        Project GetProjectWithDetails(Guid projectId);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(Project project);
    }
}
