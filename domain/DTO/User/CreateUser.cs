using FluentValidation;
using infrastructure.Db;
using infrastructure.Entities;
using infrastructure.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization; 

namespace domain.DTO.User {
    public record CreateUser: UserDTO {
        public class CreateUserValidator: AbstractValidator<CreateUser> {
            public CreateUserValidator ( ApplicationDbContext context,
                IStringLocalizer<GlobalLocalization> localizer ) {

                //Identification
                RuleFor(user => user.IdCard).Cascade(CascadeMode.Stop)
                    .NotEmpty(); 
                //Name
                RuleFor(user => user.Name).Cascade(CascadeMode.Stop) 
                  .NotEmpty()
                  .MaximumLength(100); 
                //LastName
                RuleFor(user => user.LastName).Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .MaximumLength(100); 
                //Email
                RuleFor(user => user.Email).Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .EmailAddress()
                    .MustAsync(async ( email, cancellationCoken ) => {
                        var trimmedEmail = email is null ? "" : email.Trim();
                        var alreadyExists = await context.User
                            .AnyAsync(u => u.Email == trimmedEmail, cancellationToken: cancellationCoken);

                        return !alreadyExists;
                    })
                    .WithMessage(user => localizer [ "isAlreadyRegistered",
                       user.Email is null ? "" : user.Email.Trim() ]);
                //Password
                RuleFor(user => user.Password).Cascade(CascadeMode.Stop)
                    .MinimumLength(6)
                    .NotEmpty(); 
                //Phone
                //RuleFor(user => user.Phone).Cascade(CascadeMode.Stop)
                //   .NotEmpty();
                //Avatar
                //RuleFor(user => user.Avatar).Cascade(CascadeMode.Stop)
                //   .NotEmpty();
                //Banner
                RuleFor(user => user.Banner).Cascade(CascadeMode.Stop)
                   .NotEmpty();
                //Active
                RuleFor(user => user.Active).Cascade(CascadeMode.Stop)
                   .NotNull();
                //InstitutionId
                RuleFor(user => user.InstitutionId).Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .GreaterThan(0)
                   .MustAsync(async ( institutionId, cancellationCoken ) => {
                       var exist = await context.Institution
                           .AnyAsync(u => u.Id == institutionId, cancellationToken: cancellationCoken);

                       return exist;
                   })
                    .WithMessage(user => localizer [ "notExistWithId",
                       "Institution", user.InstitutionId ]);
                //RoleId
                RuleFor(user => user.RoleId).Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .GreaterThan(0)
                   .MustAsync(async ( roleId, cancellationCoken ) => { 
                        var exist = await context.Role
                            .AnyAsync(u => u.Id == roleId, cancellationToken: cancellationCoken);

                        return exist;
                    })
                    .WithMessage(user => localizer [ "notExistWithId",
                       "Role",user.RoleId  ]);
            }
        }
    }
}
