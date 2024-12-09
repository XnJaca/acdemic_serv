 
using domain.DTO;
using domain.Utils;
using infrastructure.Entities; 

namespace domain.Services.Interfaces
{
    public interface IServiceRole
    {
        Task<Result<RoleDTO>> GetById(int id);
        Task<Result<IEnumerable<RoleDTO>>> GetAll( Filter filter, string? search );
        Task<Result<RoleDTO>> Create(RoleDTO role);
        Task<Result<RoleDTO>> Update(int id, RoleDTO role);
        Task<Result<bool>> Delete(int id);

    }
}