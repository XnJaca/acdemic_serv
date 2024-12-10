using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace infrastructure.Entities;

public class User : BaseEntity {
    
    public required string IdCard { get; set; }

    [MaxLength(100)]
    public required string Name {
        get; set;
    }

    [MaxLength(100)]
    public required string LastName {
        get; set;
    }

    [MaxLength(100)]
    public required string Email {
        get; set;
    }

    [MaxLength(255, ErrorMessage = "Jejeje te pasaste de las 255")]
    public required string Password {
        get; set;
    }

    public string? Phone { get; set; }

    public string? Avatar { get; set; }

    public required string Banner { get; set; }

    public bool Active { get; set; }

    [ForeignKey("InstitutionId")]
    public required Institution Institution { get; set; }

    public int InstitutionId { get; set; }

    [ForeignKey("RoleId")]
    public required Role Role { get; set; }

    public int RoleId { get; set; }
}