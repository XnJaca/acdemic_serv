using infrastructure.Db;
using infrastructure.Entities;
using infrastructure.Repositories.Interfaces; 

namespace infrastructure.Repositories.Implementations {
    public class UserRepository : IRepositoryUser {

        private readonly ApplicationDbContext _context;

        public UserRepository ( ApplicationDbContext context ) {
            _context = context;
        }

        public Task<Result<IEnumerable<User>>> GetAllAsync ( ) {
            // var result = await _context.User.AddAsync(role);

            //await _context.SaveChangesAsync();

            // return Result<Role>.Success(result.Entity);
            throw new NotImplementedException();
        }

        public Task<Result<User>> GetByIdAsync ( int id ) {
            throw new NotImplementedException();
        }

        public Task<Result<User>> AddAsync ( User user ) {
            throw new NotImplementedException();
        }

        public Task<Result<User>> UpdateAsync ( int id, User user ) {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteAsync ( int id ) {
            throw new NotImplementedException();
        }
    }
}
