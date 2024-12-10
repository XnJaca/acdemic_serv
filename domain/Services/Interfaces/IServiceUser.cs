using domain.DTO.User;
using domain.Utils;
using infrastructure.Entities;

namespace domain.Services.Interfaces {
    public interface IServiceUser {

        Task<Result<CreateUser>> GetById ( int id );
        Task<Result<IEnumerable<CreateUser>>> GetAll ( Filter filter, string? search );
        Task<Result<CreateUser>> Create ( CreateUser data );
        Task<Result<CreateUser>> Update ( int id, CreateUser data );
        Task<Result<bool>> Delete ( int id );

    }
}
