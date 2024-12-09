


using infrastructure.Entities;

namespace infrastructure.Repositories.Interfaces;
public interface IRepositoryUser {
    Task<Result<IEnumerable<User>>> GetAllAsync ( );
    Task<Result<User>> GetByIdAsync ( int id );
    Task<Result<User>> AddAsync ( User user );
    Task<Result<User>> UpdateAsync ( int id, User user );
    Task<Result<bool>> DeleteAsync ( int id );
}