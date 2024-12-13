using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Db;
using infrastructure.Entities;
using infrastructure.Repositories.Interfaces;
using infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace infrastructure.Repositories.Implementations
{
    public class InstitutionRepository : IRepositoryInstitution
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<InstitutionRepository> _logger;

        // private readonly IStringLocalizer<InstitutionLocalization> _localizer = localizer;

        public InstitutionRepository(ApplicationDbContext context, ILogger<InstitutionRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<Institution>> Create(Institution entity)
        {
            //print entity for debug
            _logger.LogInformation("Institution: {0}", entity.ToString());

            var result = await _context.Institution.AddAsync(entity);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Institution added");
            return Result<Institution>.Success(result.Entity);
        }

        public async Task<Result<IEnumerable<Institution>>> GetAll(PaginationFilter query)
        {
            IQueryable<Institution> InstitutionQuery = _context.Institution
            .Include(u => u.User)
            .Include(i => i.InstitutionType);

            if (query.SearchString is not null)
            {
                return await HandleSearchData(query, InstitutionQuery);
            }

            if (query.PagingData is not null)
            {
                InstitutionQuery = query.PagingData.Paginate(InstitutionQuery);
            }

            var response = await InstitutionQuery.ToListAsync();

            return Result<IEnumerable<Institution>>.Success(response);
        }

        public async Task<Result<IEnumerable<Institution>>> HandleSearchData(PaginationFilter query, IQueryable<Institution> queryable)
        {

            int pageSize = query.PagingData?.PageSize ?? 0;
            int pageKey = query.PagingData?.PageKey ?? 0;

            if (query.SearchString is null)
            {
                // return Result<IEnumerable<Role>>.Failure(_localizer["errorSearchString"]);
                return Result<IEnumerable<Institution>>.Failure("errorSearchString");
            }

            List<Institution> res = await queryable.Where(
                u =>
                u.Id > pageKey && u.Name.ToLower().Contains(query.SearchString.ToLower()) ||
                u.Id > pageKey && u.Description != null && u.Description.ToLower().Contains(query.SearchString.ToLower())
            )
            .Take(pageSize)
            .ToListAsync();

            return Result<IEnumerable<Institution>>.Success(res);
        }

        public async Task<Result<Institution>> GetById(int id)
        {
            var entity = await _context.Institution.FindAsync(id);

            return entity == null
                 ? Result<Institution>.Failure("Institution not found")
                 : Result<Institution>.Success(entity);
        }

        public async Task<Result<Institution>> Update(int id, Institution entity)
        {
            var entityToUpdate = await _context.Institution.FindAsync(id);

            if (entityToUpdate == null) { return Result<Institution>.Failure("Institution not found"); }

            _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();

            return Result<Institution>.Success(entityToUpdate);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            var item = await _context.Institution
            .FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
            {
                return Result<bool>.Failure("Institution not found");
            }

            _context.Institution.Remove(item);

            await _context.SaveChangesAsync();

            return Result<bool>.Success(true);
        }


        //TODO: Sacar la logica de validacion del rol a un servicio
        public async Task<Result<Institution>> AssignDirector(int id, int directorId)
        {
            var institution = await _context.Institution.FindAsync(id);

            if (institution == null)
            {
                return Result<Institution>.Failure("Institution not found");
            }

            var director = await _context.User
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == directorId);

            if (director == null)
            {
                return Result<Institution>.Failure("Director not found");
            }

            if (director.Role.Id != 1)
            {
                return Result<Institution>.Failure("Director role not valid");
            }

            institution.UserId = director.Id;
            institution.User = director;

            await _context.SaveChangesAsync();

            return Result<Institution>.Success(institution);
        }
    }
}
