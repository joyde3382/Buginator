using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .OrderBy(ow => ow.Name)
                .ToList();
        }

        public User GetUserById(Guid userId)
        {
            return FindByCondition(user => user.UserId.Equals(userId))
                    .FirstOrDefault();
        }

        public User GetUserWithDetails(Guid userId)
        {
            return FindByCondition(user => user.UserId.Equals(userId))
                //.Include(ac => ac.UserHasProject)
                //    .ThenInclude(userHasProject => userHasProject.ProjectProject)
                .Include(bc => bc.UserHasTicket)
                    .ThenInclude(userHasTicket => userHasTicket.TicketTicket)
                .FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            Create(user);
        }
    }
}