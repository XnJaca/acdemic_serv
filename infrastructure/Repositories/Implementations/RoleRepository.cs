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
    public class RoleRepository : IRepositoryRole
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Role>> AddAsync(Role role)
        {
            var result = await _context.Role.AddAsync(role);

            await _context.SaveChangesAsync();

            return Result<Role>.Success(result.Entity);
        }

        public async Task<Result<IEnumerable<Role>>> GetAllAsync()
        {
            var roles = await _context.Role.ToListAsync();

            return Result<IEnumerable<Role>>.Success(roles);
        }

        public async Task<Result<Role>> GetByIdAsync(int id)
        {
            var role = await _context.Role.FindAsync(id);

            return role == null
                ? Result<Role>.Failure("Role not found")
                : Result<Role>.Success(role);
        }

        public async Task<Result<Role>> UpdateAsync(int id, Role role)
        {
            var roleToUpdate = await _context.Role.FindAsync(id);

            if (roleToUpdate == null)
            {
                return Result<Role>.Failure("Role not found");
            }

            roleToUpdate.Name = role.Name;
            roleToUpdate.Description = role.Description;

            await _context.SaveChangesAsync();

            return Result<Role>.Success(roleToUpdate);

        }

    }
}