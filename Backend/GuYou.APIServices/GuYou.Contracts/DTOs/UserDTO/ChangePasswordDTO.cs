using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace GuYou.Contracts.DTOs.UserDTO
{
    public class ChangePasswordDTOValidator : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordDTOValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password is required.")
                .MinimumLength(8).WithMessage("New password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("New password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("New password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("New password must contain at least one number.")
                .Matches(@"[\!\@\#\$\%\^\&\*\(\)\_\+\-\=

\[\]

\{\}\;\:\'\""\,\.\<\>\?\\\/]").WithMessage("New password must contain at least one special character.");

            RuleFor(x => x.ConfirmedPassword)
                .Equal(x => x.NewPassword).WithMessage("Passwords do not match.");

            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("Old password is required.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.");
        }
    }

    public class ChangePasswordDTO
    {
        public required string Username { get; set; }
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
        public required string ConfirmedPassword { get; set; }
    }
}
