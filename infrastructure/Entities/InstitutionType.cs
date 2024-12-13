using System.ComponentModel.DataAnnotations;

namespace infrastructure.Entities;

public class InstitutionType : BaseEntity
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50)]
    public required string Name { get; set; }
}
