using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace infrastructure.Entities;

public class Institution
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public required string Description { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public required string Address { get; set; }

    [Required(ErrorMessage = "Phone is required")]
    public required string Phone { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public required string Email { get; set; }

    public string? Logo { get; set; }

    public string? Banner { get; set; }

    [Required(ErrorMessage = "Fundation Date is required")]
    public required DateTime FundationDate { get; set; }

    [ForeignKey("IdInstitutionType")]
    public required int IdInstitutionType { get; set; }

    public required InstitutionType InstitutionType { get; set; }

    [ForeignKey("IdUser")]
    public int? IdUser { get; set; }

    public User? User { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string? SchoolCircuit { get; set; }

    public string? RegionalAddress { get; set; }

    public bool Active { get; set; }

}
