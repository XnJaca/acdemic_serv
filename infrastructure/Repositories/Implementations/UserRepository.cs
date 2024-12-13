using infrastructure.Db;
using infrastructure.Entities;
using infrastructure.Localization;
using infrastructure.Repositories.Interfaces;
using infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace infrastructure.Repositories.Implementations {
    public class UserRepository ( ApplicationDbContext context, IStringLocalizer<GlobalLocalization> localizer ): IRepositoryUser {

        private readonly ApplicationDbContext _context = context;
        private readonly IStringLocalizer<GlobalLocalization> _localizer = localizer;

        public async Task<Result<IEnumerable<User>>> GetAllAsync ( PaginationFilter query ) {
            IQueryable<User> UserQueryable = _context.User;

            if ( query.SearchString is not null ) {
                return await HandleSearchData(query, UserQueryable);
            }

            if ( query.PagingData is not null ) {
                UserQueryable = query.PagingData.Paginate(UserQueryable);
            }

            var response = await UserQueryable.ToListAsync();

            return Result<IEnumerable<User>>.Success(response);
        }

        public async Task<Result<IEnumerable<User>>> HandleSearchData ( PaginationFilter query, IQueryable<User> queryable ) {

            int pageSize = query.PagingData?.PageSize ?? 0;
            int pageKey = query.PagingData?.PageKey ?? 0;

            if ( query.SearchString is null ) {
                return Result<IEnumerable<User>>.Failure(_localizer [ "errorSearchString" ]);
            }

            List<User> res = await queryable.Where(
                u =>
                u.Id > pageKey && u.Name.ToLower().Contains(query.SearchString.ToLower()) ||
                u.Id > pageKey && u.IdCard.ToLower().Contains(query.SearchString.ToLower()) ||
                u.Id > pageKey && u.LastName.ToLower().Contains(query.SearchString.ToLower()) ||
                u.Id > pageKey && u.Email.ToLower().Contains(query.SearchString.ToLower())
            )
            .Take(pageSize)
            .ToListAsync();

            return Result<IEnumerable<User>>.Success(res);
        }

        public Task<Result<User>> GetByIdAsync ( int id ) {
            throw new NotImplementedException();
        }

        public async Task<Result<User>> AddAsync ( User user ) {
            try {
                var userCreated = await _context.User.AddAsync(user);

                var a =  await _context.SaveChangesAsync(); 

                return Result<User>.Success(userCreated.Entity);

            } catch ( Exception ex) {
                Console.WriteLine(ex.Message);
                return Result<User>.Failure(_localizer [ "errorWhenCreate", "User" ]);
            } 
        }

        public async Task<Result<User>> UpdateAsync ( int id, User user ) {
            throw new NotImplementedException();
        }

        public async Task<Result<bool>> DeleteAsync ( int id ) {
            throw new NotImplementedException();
        }
    }
}
