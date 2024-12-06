using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using domain.DTO;
using domain.Services.Interfaces;
using infrastructure.Entities;
using infrastructure.Repositories.Interfaces;

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

            var dto = _mapper.Map<RoleDTO>(result.Data);

            return Result<RoleDTO>.Success(dto);

        }

        public async Task<Result<IEnumerable<RoleDTO>>> GetAll()
        {
            // return await _roleRepository.GetAllAsync();
            var result = await _roleRepository.GetAllAsync();

            var dto = _mapper.Map<IEnumerable<RoleDTO>>(result.Data);

            return Result<IEnumerable<RoleDTO>>.Success(dto);
        }

        public Task<Result<RoleDTO>> GetById(int id)
        {
            var result = _roleRepository.GetByIdAsync(id);

            if (!result.Result.IsSuccess)
            {
                return Task.FromResult(Result<RoleDTO>.Failure(result.Result.ErrorMessage!));
            }

            var dto = _mapper.Map<RoleDTO>(result.Result.Data);

            return Task.FromResult(Result<RoleDTO>.Success(dto));
        }

        public async Task<Result<RoleDTO>> Update(int id, RoleDTO role)
        {
            var entity = _mapper.Map<Role>(role);
            var result = await _roleRepository.UpdateAsync(id, entity);

            var dto = _mapper.Map<RoleDTO>(result.Data);

            return Result<RoleDTO>.Success(dto);

        }

        public Task<Result<bool>> Delete(int id)
        {
            return _roleRepository.DeleteAsync(id);
        }
    }
}