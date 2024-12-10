using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace domain.DTO
{
    public record UserDTO
    {
        public int Id
        {
            get; set;
        }
        public required string IdCard
        {
            get; set;
        }

        public string? Name
        {
            get; set;
        }

        public required string LastName
        {
            get; set;
        }

        public required string Email
        {
            get; set;
        }

        // public required string Password
        // {
        //     get; set;
        // }

        public string? Phone
        {
            get; set;
        }

        public string? Avatar
        {
            get; set;
        }

        public string? Banner
        {
            get; set;
        }

        public bool Active
        {
            get; set;
        }

        [JsonIgnore]
        public InstitutionDTO? Institution
        {
            get; set;
        }

        public int InstitutionId
        {
            get; set;
        }

        [JsonIgnore]
        public RoleDTO? Role
        {
            get; set;
        }

        public int RoleId
        {
            get; set;
        }
    }
}