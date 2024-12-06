using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.DTO;
using infrastructure.Entities;

namespace domain.Services.Interfaces
{
    public interface IServiceInstitutionType
    {
        Task<Result<InstitutionTypeDTO>> GetById(int id);
        Task<Result<IEnumerable<InstitutionTypeDTO>>> GetAll();
        Task<Result<InstitutionTypeDTO>> Create(InstitutionTypeDTO service);
        Task<Result<InstitutionTypeDTO>> Update(int id, InstitutionTypeDTO service);
        Task<Result<bool>> Delete(int id);
    }
}