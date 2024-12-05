using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.DTO;
using domain.Entities;

namespace domain.Services.Interfaces
{
    public interface IRepositoryInstitution
    {
        Task<Result<IEnumerable<Institution>>> GetAllAsync();
        Task<Result<Institution>> GetByIdAsync(int id);
        Task<Result<Institution>> AddAsync(Institution entity);
        Task<Result<Institution>> UpdateAsync(int id, Institution entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}