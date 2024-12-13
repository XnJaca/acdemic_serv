using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.DTO
{
    public record InstitutionTypeDTO
    {
        public int Id { get; init; }

        public required string Name { get; init; }
    }
}