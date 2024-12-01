using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.DTO;
using domain.Entities;

namespace domain.Services.Interfaces
{
    public interface IServiceRole
    {
        Task<Result<RoleDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<RoleDTO>>> GetAllAsync();
        Task<Result<RoleDTO>> AddAsync(RoleDTO role);
        Task<Result<RoleDTO>> UpdateAsync(int id, RoleDTO role);
        Task<Result<bool>> DeleteAsync(int id);

    }
}