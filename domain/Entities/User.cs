using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public required string IdCard { get; set; }

        [MaxLength(100)]
        public required string Name;

        [MaxLength(100)]
        public required string LastName;

        [MaxLength(100)]
        public required string Email;

        [MaxLength(100)]
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
}