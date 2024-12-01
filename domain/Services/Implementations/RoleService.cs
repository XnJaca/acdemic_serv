using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using domain.DTO;
using domain.Entities;
using domain.Services.Interfaces;

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

        public async Task<Result<RoleDTO>> AddAsync(RoleDTO role)
        {
            var entity = _mapper.Map<Role>(role);

            var result = await _roleRepository.AddAsync(entity);

            var dto = _mapper.Map<RoleDTO>(result.Data);

            return Result<RoleDTO>.Success(dto);

        }

        public async Task<Result<IEnumerable<RoleDTO>>> GetAllAsync()
        {
            // return await _roleRepository.GetAllAsync();
            var result = await _roleRepository.GetAllAsync();

            var dto = _mapper.Map<IEnumerable<RoleDTO>>(result.Data);

            return Result<IEnumerable<RoleDTO>>.Success(dto);
        }

        public Task<Result<RoleDTO>> GetByIdAsync(int id)
        {
            var result = _roleRepository.GetByIdAsync(id);

            var dto = _mapper.Map<RoleDTO>(result.Result.Data);

            return Task.FromResult(Result<RoleDTO>.Success(dto));
        }

        public async Task<Result<RoleDTO>> UpdateAsync(int id, RoleDTO role)
        {
            var entity = _mapper.Map<Role>(role);
            var result = await _roleRepository.UpdateAsync(id, entity);

            var dto = _mapper.Map<RoleDTO>(result.Data);

            return Result<RoleDTO>.Success(dto);

        }

        public Task<Result<bool>> DeleteAsync(int id)
        {
            return _roleRepository.DeleteAsync(id);
        }
    }
}