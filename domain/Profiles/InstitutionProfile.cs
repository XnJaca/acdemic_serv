using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using domain.DTO;
using infrastructure.Entities;

namespace domain.Profiles
{
    public class InstitutionProfile : Profile
    {
        public InstitutionProfile()
        {
            CreateMap<Institution, InstitutionDTO>()
                 .ForMember(dest => dest.User, opt => opt.MapFrom(src =>
                     src.User != null
                         ? new UserDTO
                         {
                             Id = src.User.Id,
                             IdCard = src.User.IdCard,
                             Name = src.User.Name,
                             LastName = src.User.LastName,
                             Email = src.User.Email,
                             Phone = src.User.Phone,
                             Avatar = src.User.Avatar,
                             Banner = src.User.Banner,
                             Active = src.User.Active,
                             InstitutionId = src.User.InstitutionId,
                             RoleId = src.User.RoleId
                             // Se omite src.User.Institution para evitar el ciclo
                         }
                         : null
                 ))
                 .ForMember(dest => dest.InstitutionType, opt => opt.MapFrom(src => src.InstitutionType));

            CreateMap<InstitutionDTO, Institution>();
        }
    }
}