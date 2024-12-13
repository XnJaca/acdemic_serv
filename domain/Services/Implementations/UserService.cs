using AutoMapper;
using domain.DTO.User;
using domain.Services.Interfaces;
using domain.Utils;
using infrastructure.Entities;
using infrastructure.Repositories.Interfaces;
using infrastructure.Utils;

namespace domain.Services.Implementations {
    public class UserService : IServiceUser
        {

        private readonly IRepositoryUser _userRepository;
        private readonly IMapper _mapper;

        public UserService ( IRepositoryUser userRepository, IMapper mapper ) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Result<CreateUser>>  GetById ( int id ) {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<CreateUser>>>  GetAll ( Filter filter, string? search ) {
            throw new NotImplementedException();
        }

        public async Task<Result<CreateUser>> Create ( CreateUser data ) {
            var entity = _mapper.Map<User>(data);

             var result = await _userRepository.AddAsync(entity);

            return result.Fold(
                ( success ) => Result<CreateUser>.Success(_mapper.Map<CreateUser>(success)),
                ( error ) => Result<CreateUser>.Failure(error)
            );

        }

        public async Task<Result<CreateUser>>  Update ( int id, CreateUser data ) {
            throw new NotImplementedException();
        }

        public async Task<Result<bool>>  Delete ( int id ) {
            throw new NotImplementedException();
        }
    }
}
