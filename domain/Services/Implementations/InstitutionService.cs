using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using domain.DTO;
using domain.Entities;
using domain.Services.Interfaces;

namespace domain.Services.Implementations
{
    public class InstitutionService : IServiceInstitution
    {
        private readonly IRepositoryInstitution _repository;
        private readonly IMapper _mapper;

        public InstitutionService(IRepositoryInstitution repoRepository, IMapper mapper)
        {
            _repository = repoRepository;
            _mapper = mapper;
        }

        public async Task<Result<InstitutionDTO>> Create(InstitutionDTO repo)
        {
            var entity = _mapper.Map<Institution>(repo);
            var result = await _repository.AddAsync(entity);
            var dto = _mapper.Map<InstitutionDTO>(result.Data);
            return Result<InstitutionDTO>.Success(dto);
        }

        public async Task<Result<IEnumerable<InstitutionDTO>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<InstitutionDTO>>(result.Data);
            return Result<IEnumerable<InstitutionDTO>>.Success(dto);
        }

        public Task<Result<InstitutionDTO>> GetById(int id)
        {
            var result = _repository.GetByIdAsync(id);
            var dto = _mapper.Map<InstitutionDTO>(result.Result.Data);
            return Task.FromResult(Result<InstitutionDTO>.Success(dto));
        }

        public async Task<Result<InstitutionDTO>> Update(int id, InstitutionDTO repo)
        {
            var entity = _mapper.Map<Institution>(repo);
            var result = await _repository.UpdateAsync(id, entity);
            var dto = _mapper.Map<InstitutionDTO>(result.Data);
            return Result<InstitutionDTO>.Success(dto);
        }

        public Task<Result<bool>> Delete(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}