 
using infrastructure.Db;
using infrastructure.Entities; 
using infrastructure.Repositories.Interfaces;
using infrastructure.Utils;
using Infrastructure.Localization.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization; 

namespace infrastructure.Repositories.Implementations
{
    public class RoleRepository ( ApplicationDbContext context, IStringLocalizer<RoleLocalization> localizer ): IRepositoryRole
    {
        private readonly ApplicationDbContext _context = context;
         

        private readonly IStringLocalizer<RoleLocalization> _localizer = localizer;

        public async Task<Result<Role>> AddAsync(Role role)
        {
            var result = await _context.Role.AddAsync(role);

            await _context.SaveChangesAsync();

            return Result<Role>.Success(result.Entity);
        }

        public async Task<Result<IEnumerable<Role>>> GetAllAsync( PaginationFilter query )
        { 
            IQueryable<Role> RoleQueryable = _context.Role; 

            if ( query.SearchString is not null ) { 
                return await HandleSearchData(query, RoleQueryable);
            } 

            if ( query.PagingData is not null ) {
                RoleQueryable = query.PagingData.Paginate(RoleQueryable);
            }

            var response = await RoleQueryable.ToListAsync();

            return Result<IEnumerable<Role>>.Success(response);
        }

        public   async Task<Result<IEnumerable<Role>>> HandleSearchData ( PaginationFilter query,IQueryable<Role> queryable ) {

            int pageSize = query.PagingData?.PageSize ?? 0;
            int pageKey = query.PagingData?.PageKey ?? 0;

            if ( query.SearchString is null ) {
                return Result<IEnumerable<Role>>.Failure(_localizer [ "errorSearchString" ]);
            }

            List<Role> res = await queryable.Where(
                u =>
                u.Id > pageKey && u.Name.ToLower().Contains(query.SearchString.ToLower()) ||
                u.Id > pageKey && u.Description != null && u.Description.ToLower().Contains(query.SearchString.ToLower())
            )
            .Take(pageSize)
            .ToListAsync();
              
            return Result<IEnumerable<Role>>.Success(res);
        }
         
        public async Task<Result<Role>> GetByIdAsync(int id)
        {
            var role = await _context.Role.FindAsync(id); 

            return role == null
                ? Result<Role>.Failure(_localizer [ "notFoundId", id ])
                : Result<Role>.Success(role);
        }

        public async Task<Result<Role>> UpdateAsync(int id, Role role)
        {
            var roleToUpdate = await _context.Role.FindAsync(id);

            if (roleToUpdate == null)
            {
                return Result<Role>.Failure(_localizer [ "notFoundId", id ]);
            }

            roleToUpdate.Name = role.Name;
            roleToUpdate.Description = role.Description; 

            await _context.SaveChangesAsync();

            return Result<Role>.Success(roleToUpdate);

        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var role = await _context.Role
            .Include(r => r.Users)
            .FirstOrDefaultAsync(r => r.Id == id);

            if (role == null)
            {
                return Result<bool>.Failure(_localizer [ "notFoundId", id ]);
            } 
 
            if (role.Users.Count > 0)
                
            {
                return Result<bool>.Failure(_localizer [ "cannotDeletedBecauseIsAssignUsers"]);
            }
 
            _context.Role.Remove(role);
 
            await _context.SaveChangesAsync();
 
            return Result<bool>.Success(true);
        }

    }
}