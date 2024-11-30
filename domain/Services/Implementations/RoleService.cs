using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.Entities;
using domain.Services.Interfaces;

namespace domain.Services.Implementations
{
    public class RoleService : IServiceRole
    {
        private readonly IRepositoryRole _roleRepository;

        public RoleService(IRepositoryRole roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Result<Role>> AddAsync(Role role)
        {
            return await _roleRepository.AddAsync(role);

        }

        public async Task<Result<IEnumerable<Role>>> GetAllAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public Task<Result<Role>> GetByIdAsync(int id)
        {
            return _roleRepository.GetByIdAsync(id);
        }

        public Task<Result<Role>> UpdateAsync(int id, Role role)
        {
            return _roleRepository.UpdateAsync(id, role);
        }
    }
}