using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace infrastructure.Entities;

public class Institution
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required string Address { get; set; }

    public required string Phone { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public required string Email { get; set; }

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
