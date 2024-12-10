 using System.Text.Json.Serialization; 

namespace domain.DTO.User {
    public class UserDTO {
         
        public int Id {
            get; set;
        }
        public string? IdCard {
            get; set;
        } 

        public string? Name {
            get; set;
        }

        public string? LastName {
            get; set;
        }

        public string? Email {
            get; set;
        }

        public string? Password {
            get; set;
        }

        public string? Phone {
            get; set;
        }

        public string? Avatar {
            get; set;
        }

        public string? Banner {
            get; set;
        }

        public bool Active {
            get; set;
        }

        [JsonIgnore]
        public InstitutionDTO? Institution {
            get; set;
        }

        public int InstitutionId {
            get; set;
        }

        [JsonIgnore]
        public RoleDTO? Role {
            get; set;
        }

        public int RoleId {
            get; set;
        }

    }
}
