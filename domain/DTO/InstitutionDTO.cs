using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.DTO
{
    public record InstitutionDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Address { get; set; }

        public required string Phone { get; set; }

        public required string Email { get; set; }

        public string? Logo { get; set; }

        public string? Banner { get; set; }

        public required string FundationDate { get; set; }

        public required string InstitutionType { get; set; }

        public required string User { get; set; }

        public required string Latitude { get; set; }

        public required string Longitude { get; set; }

        public required string SchoolCircuit { get; set; }

        public required string RegionalAddress { get; set; }

        public bool Active { get; set; }


    }
}