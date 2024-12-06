using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using infrastructure.Db;
using infrastructure.Entities;
using infrastructure.Repositories.Interfaces;
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

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var role = await _context.Role
            .Include(r => r.Users)
            .FirstOrDefaultAsync(r => r.Id == id);

            if (role == null)
            {
                return Result<bool>.Failure("Role not found");
            }

            if (role == null)
            {
                return Result<bool>.Failure("Role not found");
            }

            // Verificar si el rol tiene relaciones con otros registros (por ejemplo, usuarios)
            if (role.Users.Count > 0)
            {
                return Result<bool>.Failure("Cannot delete role because it is assigned to users.");
            }

            // Eliminar el rol si no tiene relaciones
            _context.Role.Remove(role);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Retornar el rol eliminado
            return Result<bool>.Success(true);
        }

    }
}