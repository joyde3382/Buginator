﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class UserForUpdateDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public List<Project> Projects { get; set; }
    }
}
