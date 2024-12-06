using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Db;
using infrastructure.Entities;
using infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace infrastructure.Repositories.Implementations
{
    public class InstitutionRepository : IRepositoryInstitution
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<InstitutionRepository> _logger;

        public InstitutionRepository(ApplicationDbContext context, ILogger<InstitutionRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<Institution>> Create(Institution entity)
        {
            _logger.LogInformation("Adding institution");

            var result = await _context.Institution.AddAsync(entity);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Institution added");
            return Result<Institution>.Success(result.Entity);
        }

        public async Task<Result<IEnumerable<Institution>>> GetAll()
        {
            var items = await _context.Institution.ToListAsync();
            return Result<IEnumerable<Institution>>.Success(items);
        }

        public async Task<Result<Institution>> GetById(int id)
        {
            var item = await _context.Institution.FindAsync(id);

            return item == null
                ? Result<Institution>.Failure("Institution not found")
                : Result<Institution>.Success(item);
        }

        public async Task<Result<Institution>> Update(int id, Institution entity)
        {
            var itemToUpdate = await _context.Institution.FindAsync(id);
            if (itemToUpdate == null) { return Result<Institution>.Failure("Institution not found"); }
            _context.Entry(itemToUpdate).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return Result<Institution>.Success(itemToUpdate);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            var item = await _context.Institution.FindAsync(id);
            if (item == null) { return Result<bool>.Failure("Institution not found"); }
            _context.Institution.Remove(item);
            await _context.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
    }
}
