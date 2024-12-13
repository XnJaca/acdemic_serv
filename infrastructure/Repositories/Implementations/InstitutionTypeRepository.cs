using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Entities;
using infrastructure.Repositories.Interfaces;
using infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories.Implementations
{
    public class InstitutionTypeRepository : IRepositoryInstitutionType
    {
        private readonly ApplicationDbContext _context;

        public InstitutionTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<InstitutionType>> Create(InstitutionType entity)
        {
            var result = await _context.InstitutionType.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Result<InstitutionType>.Success(result.Entity);
        }

        public async Task<Result<IEnumerable<InstitutionType>>> GetAll()
        {
            var items = await _context.InstitutionType.ToListAsync();
            return Result<IEnumerable<InstitutionType>>.Success(items);
        }

        public async Task<Result<InstitutionType>> GetById(int id)
        {
            var item = await _context.InstitutionType.FindAsync(id);
            
            return item == null
                ? Result<InstitutionType>.Failure("InstitutionType not found")
                : Result<InstitutionType>.Success(item);
        }

        public async Task<Result<InstitutionType>> Update(int id, InstitutionType entity)
        {
            var itemToUpdate = await _context.InstitutionType.FindAsync(id);
            if (itemToUpdate == null) { return Result<InstitutionType>.Failure("InstitutionType not found"); }
            _context.Entry(itemToUpdate).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return Result<InstitutionType>.Success(itemToUpdate);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            var item = await _context.InstitutionType.FindAsync(id);
            if (item == null) { return Result<bool>.Failure("InstitutionType not found"); }
            _context.InstitutionType.Remove(item);
            await _context.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
    }
}