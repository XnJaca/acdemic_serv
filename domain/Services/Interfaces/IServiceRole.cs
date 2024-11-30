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
        Task<Result<Role>> AddAsync(Role role);
        Task<Result<Role>> UpdateAsync(int id, Role role);

    }
}