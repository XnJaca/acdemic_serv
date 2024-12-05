using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.DTO;
using domain.Entities;

namespace domain.Services.Interfaces
{
    public interface IServiceInstitution
    {
        Task<Result<InstitutionDTO>> GetById(int id);
        Task<Result<IEnumerable<InstitutionDTO>>> GetAll();
        Task<Result<InstitutionDTO>> Create(InstitutionDTO service);
        Task<Result<InstitutionDTO>> Update(int id, InstitutionDTO service);
        Task<Result<bool>> Delete(int id);
    }
}