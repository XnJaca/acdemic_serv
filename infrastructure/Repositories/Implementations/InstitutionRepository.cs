using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.Entities;
using domain.Services.Interfaces;
using infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories.Implementations
{
    public class InstitutionRepository : IRepositoryInstitution
    {
        private readonly ApplicationDbContext _context;

        public InstitutionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Institution>> AddAsync(Institution entity)
        {
            var result = await _context.Institution.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Result<Institution>.Success(result.Entity);
        }

        public async Task<Result<IEnumerable<Institution>>> GetAllAsync()
        {
            var items = await _context.Institution.ToListAsync();
            return Result<IEnumerable<Institution>>.Success(items);
        }

        public async Task<Result<Institution>> GetByIdAsync(int id)
        {
            var item = await _context.Institution.FindAsync(id);
            return item == null
                ? Result<Institution>.Failure("Institution not found")
                : Result<Institution>.Success(item);
        }

        public async Task<Result<Institution>> UpdateAsync(int id, Institution entity)
        {
            var itemToUpdate = await _context.Institution.FindAsync(id);
            if (itemToUpdate == null) { return Result<Institution>.Failure("Institution not found"); }
            _context.Entry(itemToUpdate).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return Result<Institution>.Success(itemToUpdate);
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var item = await _context.Institution.FindAsync(id);
            if (item == null) { return Result<bool>.Failure("Institution not found"); }
            _context.Institution.Remove(item);
            await _context.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
    }
}