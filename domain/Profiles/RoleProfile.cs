using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using domain.DTO;
using infrastructure.Entities;

namespace domain.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>();

            CreateMap<RoleDTO, Role>();
        }
    }
}