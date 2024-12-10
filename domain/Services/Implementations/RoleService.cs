using AutoMapper;
using domain.DTO;
using domain.Services.Interfaces;
using domain.Utils;
using infrastructure.Entities;
using infrastructure.Repositories.Interfaces;
using infrastructure.Utils;

namespace domain.Services.Implementations
{
    public class RoleService : IServiceRole
    {
        private readonly IRepositoryRole _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRepositoryRole roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<Result<RoleDTO>> Create(RoleDTO role)
        {
            var entity = _mapper.Map<Role>(role);

            var result = await _roleRepository.AddAsync(entity);

            return result.Fold(
                ( success ) => Result<RoleDTO>.Success(_mapper.Map<RoleDTO>(result.Data)),
                ( error ) => Result<RoleDTO>.Failure(error)
            ); 
        }

        public async Task<Result<IEnumerable<RoleDTO>>> GetAll( Filter filter, string? search ) {

            var query = new PaginationFilter { SearchString = search, PagingData = filter.ToPaginData() };

            var result = await _roleRepository.GetAllAsync(query);

            return result.Fold(
               ( success ) => Result<IEnumerable<RoleDTO>>.Success(_mapper.Map<IEnumerable<RoleDTO>>(result.Data)),
               ( error ) => Result<IEnumerable<RoleDTO>>.Failure(error)
            ); 
        }

        public async Task<Result<RoleDTO>> GetById (int id)
        {
            Result<Role> result = await _roleRepository.GetByIdAsync(id);
  
            return result.Fold(
                ( success ) => Result<RoleDTO>.Success(_mapper.Map<RoleDTO>(success)) ,
                ( error ) =>  Result<RoleDTO>.Failure(error)
            ); 
        }

        public async Task<Result<RoleDTO>> Update(int id, RoleDTO role)
        {
            var entity = _mapper.Map<Role>(role); 
            var result = await _roleRepository.UpdateAsync(id, entity);

            return result.Fold(
               ( success ) => Result<RoleDTO>.Success(_mapper.Map<RoleDTO>(success)),
               ( error ) => Result<RoleDTO>.Failure(error)
            );  
        }

        public async Task<Result<bool>> Delete(int id)
        {
             var result = await _roleRepository.DeleteAsync(id);

            return result.Fold(
              ( success ) => Result<bool>.Success(success),
              ( error ) => Result<bool>.Failure(error)
            );
        }
    }
}