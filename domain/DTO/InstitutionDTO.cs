using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Entities;

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

        public DateTime FundationDate { get; set; }

        public required int InstitutionTypeId { get; set; }

        public InstitutionType? InstitutionType { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

        public string? Logo { get; set; }

        public string? Banner { get; set; }

        public string? Latitude { get; set; }

        public string? Longitude { get; set; }

        public string? SchoolCircuit { get; set; }

        public string? RegionalAddress { get; set; }

        public bool Active { get; set; }



    }
}