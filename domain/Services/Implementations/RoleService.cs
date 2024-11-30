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
        public Task AddAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<Role>>> GetAllAsync()
        {
            // return await _roleRepository.GetAllAsync();
            throw new NotImplementedException();
        }

        public Task<Result<Role>> GetByIdAsync(int id)
        {
            return _roleRepository.GetByIdAsync(id);
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}