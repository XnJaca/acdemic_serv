using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Entities;

namespace infrastructure.Repositories.Interfaces
{
    public interface IRepositoryInstitutionType
    {
        Task<Result<IEnumerable<InstitutionType>>> GetAll();
        Task<Result<InstitutionType>> GetById(int id);
        Task<Result<InstitutionType>> Create(InstitutionType entity);
        Task<Result<InstitutionType>> Update(int id, InstitutionType entity);
        Task<Result<bool>> Delete(int id);
    }
}