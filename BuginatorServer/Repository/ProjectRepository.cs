using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            RepositoryContext _dbContext = repositoryContext;
        }
        public IEnumerable<Project> ProjectsByUser(Guid userId)
        {
            // Not working
            return FindByCondition(a => a.UserHasProject.Where(x => x.UserUserId.Equals(userId)).SelectMany(x => x.ProjectProject).ToList());

        }

    }
}