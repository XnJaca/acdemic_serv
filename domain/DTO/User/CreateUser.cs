using FluentValidation;
using infrastructure.Db;
using infrastructure.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization; 

namespace domain.DTO.User {
    public class CreateUser: UserDTO {
        public class CreateUserValidator: AbstractValidator<CreateUser> {
            public CreateUserValidator ( ApplicationDbContext context,
                IStringLocalizer<GlobalLocalization> localizer ) {

                RuleFor(usuario => usuario.Name).Cascade(CascadeMode.Stop)
                  .NotEmpty()
                  .MustAsync(async ( nombre, cancellationToken ) => {
                      var trimmedNombre = nombre is null ? "" : nombre.Trim();
                      var alreadyExists = await context.User
                          .AnyAsync(u => u.Name == trimmedNombre);

                      return !alreadyExists;
                  })
                   .WithMessage(usuario => localizer [ "\"{0}\" is already registered.",
              usuario.Name is null ? "" : usuario.Name.Trim() ]);

                RuleFor(usuario => usuario.Email).Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .EmailAddress()
                    .MustAsync(async ( email, cancellationCoken ) => {
                        var trimmedEmail = email is null ? "" : email.Trim();
                        var alreadyExists = await context.User
                            .AnyAsync(u => u.Email == trimmedEmail);

                        return !alreadyExists;
                    })
                    .WithMessage(usuario => localizer [ "\"{0}\" is already registered.",
                       usuario.Email is null ? "" : usuario.Email.Trim() ]);

                RuleFor(usuario => usuario.Password).NotEmpty();
            }
        }
    }
}
