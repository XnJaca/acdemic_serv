using infrastructure.Entities;

namespace infrastructure.Repositories.Interfaces;

public interface IRepositoryInstitution
{
    Task<Result<IEnumerable<Institution>>> GetAll();
    Task<Result<Institution>> GetById(int id);
    Task<Result<Institution>> Create(Institution entity);
    Task<Result<Institution>> Update(int id, Institution entity);
    Task<Result<bool>> Delete(int id);
}
