using AutoMapper;
using domain.DTO;
using domain.DTO.User;
using infrastructure.Entities;

namespace domain.Profiles {
    public class MapingProfiles: Profile {

        public MapingProfiles () {
            CreateMap<RoleDTO, Role>().ReverseMap();
            CreateMap<CreateUser, User>().ReverseMap();
        }
         
    }
}
