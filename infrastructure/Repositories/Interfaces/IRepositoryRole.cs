

using infrastructure.Entities;

namespace infrastructure.Repositories.Interfaces;

public interface IRepositoryRole
{
    Task<Result<IEnumerable<Role>>> GetAllAsync();
    Task<Result<Role>> GetByIdAsync(int id);
    Task<Result<Role>> AddAsync(Role role);
    Task<Result<Role>> UpdateAsync(int id, Role role);
    Task<Result<bool>> DeleteAsync(int id);

}
