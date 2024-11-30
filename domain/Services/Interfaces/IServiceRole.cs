using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.Entities;

namespace domain.Services.Interfaces
{
    public interface IServiceRole
    {
        Task<Result<Role>> GetByIdAsync(int id);
        Task<Result<IEnumerable<Role>>> GetAllAsync();
        Task AddAsync(Role role);
        Task SaveAsync();

    }
}