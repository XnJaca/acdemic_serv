using infrastructure.Entities;
using infrastructure.Utils;

namespace infrastructure.Repositories.Interfaces;

public interface IRepositoryInstitution
{
    Task<Result<IEnumerable<Institution>>> GetAll(PaginationFilter query);

    Task<Result<Institution>> AssignDirector(int id, int directorId);
    Task<Result<Institution>> GetById(int id);
    Task<Result<Institution>> Create(Institution entity);
    Task<Result<Institution>> Update(int id, Institution entity);
    Task<Result<bool>> Delete(int id);
}
