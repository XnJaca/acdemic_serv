using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using domain.DTO;
using domain.Services.Interfaces;
using domain.Utils;
using infrastructure.Entities;
using infrastructure.Repositories.Interfaces;
using infrastructure.Utils;
using Microsoft.Extensions.Logging;

namespace domain.Services.Implementations
{
    public class InstitutionService : IServiceInstitution
    {

        private readonly ILogger<InstitutionService> _logger;
        private readonly IRepositoryInstitution _repository;
        private readonly IRepositoryInstitutionType _repositoryInstitutionType;
        private readonly IMapper _mapper;

        public InstitutionService(IRepositoryInstitution repoRepository,
            IMapper mapper, IRepositoryInstitutionType repositoryInstitutionType, ILogger<InstitutionService> logger)
        {
            _repository = repoRepository;
            _mapper = mapper;
            _repositoryInstitutionType = repositoryInstitutionType;
            _logger = logger;
        }

        public async Task<Result<InstitutionDTO>> Create(InstitutionDTO institution)
        {

            // Validar que el tipo de institución exista
            var institutionType = await _repositoryInstitutionType.GetById(institution.InstitutionTypeId);

            _logger.LogInformation("InstitutionType: {0}", institutionType);
            if (!institutionType.IsSuccess)
            {
                return Result<InstitutionDTO>.Failure("El tipo de institución no existe");
            }

            var entity = _mapper.Map<Institution>(institution);

            var result = await _repository.Create(entity);

            return result.Fold(
                (success) => Result<InstitutionDTO>.Success(_mapper.Map<InstitutionDTO>(result.Data)),
                Result<InstitutionDTO>.Failure
            );
        }

        public async Task<Result<IEnumerable<InstitutionDTO>>> GetAll(Filter filter, string? search)
        {
            var query = new PaginationFilter { SearchString = search, PagingData = filter.ToPaginData() };

            var result = await _repository.GetAll(query);

            return result.Fold(
                (success) => Result<IEnumerable<InstitutionDTO>>.Success(_mapper.Map<IEnumerable<InstitutionDTO>>(result.Data)),
                Result<IEnumerable<InstitutionDTO>>.Failure
            );
        }

        public async Task<Result<InstitutionDTO>> GetById(int id)
        {
            Result<Institution> result = await _repository.GetById(id);
            return result.Fold(
                (success) => Result<InstitutionDTO>.Success(_mapper.Map<InstitutionDTO>(result.Data)),
                Result<InstitutionDTO>.Failure
            );
        }

        public async Task<Result<InstitutionDTO>> Update(int id, InstitutionDTO institution)
        {
            var entity = _mapper.Map<Institution>(institution);

            var result = await _repository.Update(id, entity);

            return result.Fold(
                (success) => Result<InstitutionDTO>.Success(_mapper.Map<InstitutionDTO>(result.Data)),
                Result<InstitutionDTO>.Failure
            );
        }

        public async Task<Result<bool>> Delete(int id)
        {
            var result = await _repository.Delete(id);

            return result.Fold(
                (success) => Result<bool>.Success(success),
                Result<bool>.Failure
            );
        }

        public async Task<Result<InstitutionDTO>> AssignDirector(int id, int directorId)
        {
            var result = await _repository.AssignDirector(id, directorId);

            return result.Fold(
                (success) => Result<InstitutionDTO>.Success(_mapper.Map<InstitutionDTO>(result.Data)),
                Result<InstitutionDTO>.Failure
            );
        }
    }
}