using GuYou.Repositories.Configure;
using GuYou.Contracts.DTOs;
using GuYou.Contracts.DTOs.Paging;
using GuYou.Contracts.DTOs.UserDTO;
using GuYou.Repositories.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Interfaces
{
    public interface IAuthenticateService
    {
        Task<UserDTO> RegisterAsync(UserDTO userDTO);
        Task<LoginResponse> LoginAsync(string username, string password);
        Task<LoginResponse> LoginByGoogleAsync(string email);
        Task<LoginResponse> RefreshTokenAsync(string token, string refreshToken);
        Task<LoginResponse> RevokeRefreshTokenAsync(string refreshToken);
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserResponse>> GetUsers();
        Task<User> GetUserByIdAsync(string userId);
        Task<string> GetUserEmailByIdAsync(string userId);
        Task<IEnumerable<User>> GetUsersByFullNameAsync(string fullName);
        Task<IdentityResult> UpdateUserAsync(UpdateUserDTO user);
        Task<IdentityResult> ChangeUserPasswordAsync(ChangePasswordDTO request);
        Task<bool> DeactiveUserAsync(string userId);
        Task<bool> ActiveUserAsync(string userId);
        Task<User?> GetUserByRefreshTokenAsync(string refreshToken);
        Task ForgotPassword(string email, EnvironmentType type);
        Task<IdentityResult> ResetPassword(ResetPasswordDTO request);
        Task<Dictionary<string, string>> GetFullNamesByIdsAsync(IEnumerable<string> userIds);
        Task<IdentityResult> VerifyOTP(string email, string otp);
    }
}
