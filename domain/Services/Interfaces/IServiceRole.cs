using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.DTO;
using infrastructure.Entities;

namespace domain.Services.Interfaces
{
    public interface IServiceRole
    {
        Task<Result<RoleDTO>> GetById(int id);
        Task<Result<IEnumerable<RoleDTO>>> GetAll();
        Task<Result<RoleDTO>> Create(RoleDTO role);
        Task<Result<RoleDTO>> Update(int id, RoleDTO role);
        Task<Result<bool>> Delete(int id);

    }
}