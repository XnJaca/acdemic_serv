using FluentValidation;
using infrastructure.Db;
using infrastructure.Entities;
using infrastructure.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization; 

namespace domain.DTO.User {
    public record UpdateUser : UserDTO { 

        public class UpdateUserValidator: AbstractValidator<UpdateUser> {
            public UpdateUserValidator ( ApplicationDbContext context,
                IStringLocalizer<GlobalLocalization> localizer ) {
                //Name
                RuleFor(user => user.Name).Cascade(CascadeMode.Stop)
                  .NotEmpty()
                  .When(user => user.Name != null);
                //Email
                RuleFor(user => user.Email).Cascade(CascadeMode.Stop) 
                    .NotEmpty()
                    .When(user => user.Email != null)
                    .EmailAddress() 
                    .MustAsync(async ( email, cancellationCoken ) => {
                        var trimmedEmail = email is null ? "" : email.Trim();

                        var alreadyExists = await context.User.AnyAsync(u => u.Email == trimmedEmail, cancellationToken: cancellationCoken);

                        return !alreadyExists;
                    }).WithMessage(user => localizer [ "isAlreadyRegistered",
                       user.Email is null ? "" : user.Email.Trim() ]);
                //Password
                RuleFor(usuario => usuario.Password)
                    .NotEmpty()
                    .When(user => user.Password != null);


            }
        }

    }
}
