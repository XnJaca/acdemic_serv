using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace infrastructure.Entities;

public class User {
    public int Id { get; set; }

    public required string IdCard { get; set; }

    [MaxLength(100)]
    public required string Name;

    [MaxLength(100)]
    public required string LastName;

    [MaxLength(100)]
    public required string Email;

    [MaxLength(255,ErrorMessage ="Jejeje te pasaste de las 255")]
    public required string Password;

    public string? Phone { get; set; }

    public string? Avatar { get; set; }

    public required string Banner { get; set; }

    public bool Active { get; set; }

    [ForeignKey("IdInstitution")]
    public required Institution Institution { get; set; }

    public int IdInstitution { get; set; }

    [ForeignKey("RoleId")]
    public required Role Role { get; set; }

    public int RoleId { get; set; }
}