﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid userId);
        User GetUserWithDetails(Guid userId);
        void CreateUser(User user);
    }
}
