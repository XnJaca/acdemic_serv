using AutoMapper;
using domain.DTO;
using infrastructure.Entities; 

namespace domain.Profiles {
    public class MapingProfiles: Profile {

        public MapingProfiles () {
            CreateMap<RoleDTO, Role>().ReverseMap();
        }
         
    }
}
