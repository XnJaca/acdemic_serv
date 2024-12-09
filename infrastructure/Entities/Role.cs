using System.ComponentModel.DataAnnotations;

namespace infrastructure.Entities;

public class Role: BaseEntity { 

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
}
