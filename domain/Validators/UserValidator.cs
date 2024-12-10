using domain.DTO.User;
using FluentValidation;
using infrastructure.Db;
using infrastructure.Localization;
using Microsoft.Extensions.Localization;

namespace domain.Validators {
    public class UserValidator   {

        //public class CreateUserCommandValidator: AbstractValidator<CreateUser> {
        //    public CreateUserCommandValidator ( ApplicationDbContext context,
        //        IStringLocalizer<GlobalLocalization> localizer ) {

        //        RuleFor(r => r.Name)
        //        .NotEmpty()
        //        //.WithMessage(localizer [ "IsRequired", "Name" ])
        //        .MaximumLength(100)
        //        .WithMessage(localizer [ "NameTooLong" ]);
        //    }
        //}

        //public class UpdateUserCommandValidator : AbstractValidator<UpdateUser> {
        //    public UpdateUserCommandValidator ( ApplicationDbContext context,
        //        IStringLocalizer<GlobalLocalization> localizer ) {

        //        RuleFor(r => r.Name)
        //        .NotEmpty()
        //        .WithMessage("UPDATE")
        //        .MaximumLength(100)
        //        .WithMessage(localizer [ "NameTooLong" ]);
        //    }
        //}
    }
}
