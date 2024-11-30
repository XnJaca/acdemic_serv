using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Institution
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Logo { get; set; }

        public string? Banner { get; set; }

        public required string FundationDate { get; set; }

        [ForeignKey("IdInstitutionType")]
        public int IdInstitutionType { get; set; }

        public required InstitutionType InstitutionType { get; set; }

        [ForeignKey("IdUser")]
        public int IdUser { get; set; }

        public required User User { get; set; }

        public required string Latitude { get; set; }

        public required string Longitude { get; set; }

        public required string SchoolCircuit { get; set; }

        public required string RegionalAddress { get; set; }

        public bool Active { get; set; }
    }
}