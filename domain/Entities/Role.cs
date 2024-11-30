using System.ComponentModel.DataAnnotations;

namespace domain.Entities;

public class Role
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
