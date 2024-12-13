


using infrastructure.Entities;
using infrastructure.Utils;

namespace infrastructure.Repositories.Interfaces;
public interface IRepositoryUser {
    Task<Result<IEnumerable<User>>> GetAllAsync ( PaginationFilter query );
    Task<Result<User>> GetByIdAsync ( int id );
    Task<Result<User>> AddAsync ( User user );
    Task<Result<User>> UpdateAsync ( int id, User user );
    Task<Result<bool>> DeleteAsync ( int id );
}