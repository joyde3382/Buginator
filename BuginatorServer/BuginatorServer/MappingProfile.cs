﻿using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuginatorServer
{
public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserForUpdateDto, User>();

            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectForCreationDto, Project>();
            CreateMap<ProjectForUpdateDto, Project>();

            CreateMap<Ticket, TicketDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<UserHasProject, UserHasProjectDto>();
            CreateMap<UserHasTicket, UserHasTicketDto>();
        }
    }
}
