﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Contracts.DTOs.UserDTO
{
    public class ResetPasswordDTOValidator : AbstractValidator<ResetPasswordDTO>
    {
        public ResetPasswordDTOValidator()
        {
            RuleFor(model => model.Email)
                .NotEmpty().WithMessage("Email không được để trống!")
                .EmailAddress().WithMessage("Sai định dạng Email.");
            RuleFor(model => model.NewPassword)
                .NotEmpty().WithMessage("Mật khẩu mới không được để trống!")
                .MinimumLength(8).WithMessage("Mật khẩu mới phải có ít nhất 8 ký tự.")
                .MaximumLength(20).WithMessage("Mật khẩu mới không vượt quá 20 ký tự.")
                .Matches("[A-Z]").WithMessage("Mật khẩu mới phải chứa ít nhất 1 ký tự in hoa.")
                .Matches("[a-z]").WithMessage("Mật khẩu mới phải chứa ít nhất 1 ký tự in thường.")
                .Matches("[0-9]").WithMessage("Mật khẩu mới phải chứa ít nhất 1 ký tự số.")
                .Matches("[!@#$%^&*]").WithMessage("Mật khẩu mới phải chứa ít nhất 1 ký tự đặc biệt.");
            RuleFor(modle => modle.ConfirmPassword)
                .NotEmpty().WithMessage("Mật khẩu xác nhận không được để trống!")
                .Equal(model => model.NewPassword).WithMessage("Mật khẩu xác nhận không khớp với Mật khẩu mới!");
        }
    }
    public class ResetPasswordDTO
    {
        public ResetPasswordDTO(string email, string otp, string newPassword, string confirmPassword)
        {
            Email = email;
            NewPassword = newPassword;
            OTP = otp;
            ConfirmPassword = confirmPassword;
        }
        public string Email { get; set; }
        public string OTP { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
