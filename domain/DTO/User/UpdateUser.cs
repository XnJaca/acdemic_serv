using FluentValidation;
using infrastructure.Db;
using infrastructure.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System.Reflection;
using System.Text.Json.Serialization; 

namespace domain.DTO.User {
    public class UpdateUser : UserDTO {
        [JsonIgnore]
        public int RouteId {
            get; set;
        }
        public static ValueTask<UpdateUser?> BindAsync ( HttpContext context, ParameterInfo parameter ) {
            var request = context.Request;
            var id = 0;
            if ( request.RouteValues.ContainsKey("id") ) {
                int.TryParse(request.RouteValues [ "id" ]?.ToString(), out id);
            }

            return ValueTask.FromResult<UpdateUser?>(new UpdateUser() {
                Id = id
            });
        }

        public class UpdateUserValidator: AbstractValidator<UpdateUser> {
            public UpdateUserValidator ( ApplicationDbContext context,
                IStringLocalizer<GlobalLocalization> localizer ) {
                //When(user => user.Id == user.RouteId, ( ) => {
                //    RuleFor(r => r.Name)
                //   .NotEmpty()
                //   .WithMessage("UPDATE")
                //   .MaximumLength(100)
                //   .WithMessage(localizer [ "NameTooLong" ]);
                //});

                RuleFor(r => r.Name)
                  .NotEmpty()
                  .WithMessage("UPDATE")
                  .MaximumLength(100)
                  .WithMessage(localizer [ "NameTooLong" ]);


            }
        }

    }
}
