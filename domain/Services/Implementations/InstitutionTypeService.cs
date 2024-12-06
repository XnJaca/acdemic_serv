using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using domain.DTO;
using infrastructure.Entities;
using domain.Services.Interfaces;
using infrastructure.Repositories.Interfaces;

namespace domain.Services.Implementations
{
    public class InstitutionTypeService : IServiceInstitutionType
    {
        private readonly IRepositoryInstitutionType _repository;
        private readonly IMapper _mapper;

        public InstitutionTypeService(IRepositoryInstitutionType repoRepository, IMapper mapper)
        {
            _repository = repoRepository;
            _mapper = mapper;
        }

        public async Task<Result<InstitutionTypeDTO>> Create(InstitutionTypeDTO repo)
        {
            var entity = _mapper.Map<InstitutionType>(repo);
            var result = await _repository.Create(entity);
            var dto = _mapper.Map<InstitutionTypeDTO>(result.Data);
            return Result<InstitutionTypeDTO>.Success(dto);
        }

        public async Task<Result<IEnumerable<InstitutionTypeDTO>>> GetAll()
        {
            var result = await _repository.GetAll();
            var dto = _mapper.Map<IEnumerable<InstitutionTypeDTO>>(result.Data);
            return Result<IEnumerable<InstitutionTypeDTO>>.Success(dto);
        }

        public Task<Result<InstitutionTypeDTO>> GetById(int id)
        {
            var result = _repository.GetById(id);
            var dto = _mapper.Map<InstitutionTypeDTO>(result.Result.Data);
            return Task.FromResult(Result<InstitutionTypeDTO>.Success(dto));
        }

        public async Task<Result<InstitutionTypeDTO>> Update(int id, InstitutionTypeDTO repo)
        {
            var entity = _mapper.Map<InstitutionType>(repo);
            var result = await _repository.Update(id, entity);
            var dto = _mapper.Map<InstitutionTypeDTO>(result.Data);
            return Result<InstitutionTypeDTO>.Success(dto);
        }

        public Task<Result<bool>> Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}