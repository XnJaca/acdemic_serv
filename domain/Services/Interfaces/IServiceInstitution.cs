using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.DTO;
using domain.Utils;
using infrastructure.Entities;

namespace domain.Services.Interfaces
{
    public interface IServiceInstitution
    {
        Task<Result<InstitutionDTO>> GetById(int id);
        Task<Result<InstitutionDTO>> AssignDirector(int id, int directorId);
        Task<Result<IEnumerable<InstitutionDTO>>> GetAll(Filter filter, string? search);
        Task<Result<InstitutionDTO>> Create(InstitutionDTO service);
        Task<Result<InstitutionDTO>> Update(int id, InstitutionDTO service);
        Task<Result<bool>> Delete(int id);
    }
}