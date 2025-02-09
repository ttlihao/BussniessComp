using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using GuYou.Repositories.DTOs;
using GuYou.Repositories.Models;
using GuYou.Services.Interfaces;
using GuYou.Repositories.Repositories.Interfaces;
using GuYou.Repositories.Base;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using GuYou.Repositories.Configure;

namespace GuYou.Services.Implements
{
    public class AuthenticateService : GenericRepository<User>, IAuthenticateService
    {
        private readonly IUserRepository _authenticateRepo;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly int _exAccessToken;
        private readonly int _exRefreshToken;
        private readonly ITimeService _timeService;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;

        public AuthenticateService(RoleManager<IdentityRole> roleManager, IMapper mapper, IUserRepository authenticateRepo, IConfiguration configuration, UserManager<User> userManager, ITimeService timeService, IUserContextService userContextService, IEmailService emailService)
        {
            _authenticateRepo = authenticateRepo;
            _configuration = configuration;
            _userManager = userManager;
            _exAccessToken = int.Parse(_configuration["Jwt:ExpirationAccessToken"]!);
            _exRefreshToken = int.Parse(_configuration["Jwt:ExpirationRefreshToken"]!);
            _timeService = timeService;
            _mapper = mapper;
            _roleManager = roleManager;
            _userContextService = userContextService;
            _emailService = emailService;
        }

        public async Task<IEnumerable<User>> GetUsersByFullNameAsync(string fullName)
        {
            return await _authenticateRepo.GetUsersByFullNameAsync(fullName);
        }

        public async Task<string> GetUserEmailByIdAsync(string userId)
        {
            return await _authenticateRepo.GetUserEmailByIdAsync(userId);
        }

        public async Task<User?> GetUserByRefreshTokenAsync(string refreshToken)
        {
            return await _authenticateRepo.GetUserByRefreshTokenAsync(refreshToken);
        }

        public async Task<IdentityResult> UpdateUserAsync(UpdateUserDTO user)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser == null)
            {
                throw new ArgumentException("Không tìm thấy người dùng");
            }
            existingUser = _mapper.Map(user, existingUser);
            existingUser.LastUpdatedBy = _userContextService.GetCurrentUserId();
            existingUser.LastUpdatedTime = _timeService.SystemTimeNow;
            return await _userManager.UpdateAsync(existingUser);
        }

        public async Task<string?> GetUserNameByIdAsync(object id)
        {
            return await _authenticateRepo.GetUserNameByIdAsync(id);
        }

        public async Task<Dictionary<string, string>> GetFullNamesByIdsAsync(IEnumerable<string> userIds)
        {
            return await _authenticateRepo.GetFullNamesByIdsAsync(userIds);
        }

        public async Task<UserDTO> RegisterAsync(UserDTO userDTO)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == userDTO.Username))
                throw new ArgumentException("User đã tồn tại.");



            //user
            User newUser = _mapper.Map<User>(userDTO);
            newUser.IsActive = true;
            newUser.IsDelete = false;
            IdentityResult resultCreateUser = await _userManager.CreateAsync(newUser, userDTO.Password);
            if (!resultCreateUser.Succeeded)
                throw new ArgumentException("Đã có lỗi xảy ra");

            // Role by ID
            var roleID = userDTO.RoleID;
            IdentityRole? getRoleID = await _roleManager.FindByIdAsync(roleID);

            if (getRoleID == null)
            {
                throw new ArgumentException("Vai trò không tồn tại.");
            }

            IdentityResult resultAddRoleID = await _userManager.AddToRoleAsync(newUser, getRoleID.Name!);

            if (!resultAddRoleID.Succeeded)
            {
                throw new ArgumentException("Không thể thêm vai trò cho người dùng.");
            }


            return _mapper.Map<UserDTO>(newUser);
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username) ??
                    throw new ArgumentException("Wrong username");
                var checkPassword = await _userManager.CheckPasswordAsync(user, password);
                if (!checkPassword)
                {
                    throw new ArgumentException("Wrong password");
                }

                var roles = await _userManager.GetRolesAsync(user);
                var userRole = roles.FirstOrDefault();
                if (userRole == null)
                {
                    throw new ArgumentException("Người dùng chưa được cấp quyền");
                }

                // Generate access token
                var accessToken = GenerateToken(user.Id, userRole, false);
                // Generate refresh token
                var refreshToken = GenerateToken(user.Id, userRole, true);

                // Save Database
                user.VerificationToken = accessToken;
                user.ResetToken = refreshToken;
                user.VerificationTokenExpires = _timeService.SystemTimeNow.AddHours(_exRefreshToken);
                user.VerificationTokenExpires = _timeService.SystemTimeNow.AddHours(_exRefreshToken);
                user.ResetTokenExpires = _timeService.SystemTimeNow.AddHours(_exAccessToken);
                await _userManager.UpdateAsync(user);
                return new LoginResponse
                {
                    VerificationToken = accessToken,
                    ResetToken = refreshToken,
                    UserId = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    RoleName = userRole
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<LoginResponse> RefreshTokenAsync(string token, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> RevokeRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            try
            {
                var user = await _authenticateRepo.GetUsesByIdAsync(userId);
                if (user == null)
                {
                    throw new ArgumentException("Không tìm thấy người dùng");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private string GenerateToken(string userId, string role, bool isRefreshToken)
        {
            try
            {
                var keyString = _configuration["Jwt:Key"]
                     ?? throw new ArgumentException("JWT key is not configured.");
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim("Id", userId),
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                if (isRefreshToken)
                {
                    claims.Add(new Claim("isRefreshToken", "true"));
                }

                DateTime expiresDateTime;
                if (isRefreshToken)
                {
                    expiresDateTime = _timeService.SystemTimeNow.AddDays(_exRefreshToken).DateTime;
                }
                else
                {
                    expiresDateTime = _timeService.SystemTimeNow.AddDays(_exAccessToken).DateTime;
                }


                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: expiresDateTime,
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _authenticateRepo.GetUserByEmailAsync(email);
                if (user == null)
                {
                    throw new ArgumentException("Không tìm thấy người dùng");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<LoginResponse> LoginByGoogleAsync(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email) ??
                    throw new ArgumentException("Email chưa được đăng ký");

                var roles = await _userManager.GetRolesAsync(user);
                var userRole = roles.FirstOrDefault();
                if (userRole == null)
                {
                    throw new ArgumentException("Người dùng chưa được cấp quyền");
                }

                // Generate access token
                var accessToken = GenerateToken(user.Id, userRole, false);
                // Generate refresh token
                var refreshToken = GenerateToken(user.Id, userRole, true);

                // Save Database
                user.VerificationToken = accessToken;
                user.ResetToken = refreshToken;
                user.VerificationTokenExpires = _timeService.SystemTimeNow.AddDays(_exRefreshToken);
                user.VerificationTokenExpires = _timeService.SystemTimeNow.AddDays(_exRefreshToken);
                user.ResetTokenExpires = _timeService.SystemTimeNow.AddDays(_exAccessToken);
                await _userManager.UpdateAsync(user);
                return new LoginResponse
                {
                    VerificationToken = accessToken,
                    ResetToken = refreshToken,
                    UserId = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    RoleName = userRole
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeactiveUserAsync(string id)
        {
            var existingUser = await _userManager.FindByIdAsync(id);
            if (existingUser != null)
            {
                existingUser.IsActive = false;
                existingUser.IsDelete = true;
                existingUser.DeletedTime = _timeService.SystemTimeNow;
                existingUser.LastUpdatedBy = _userContextService.GetCurrentUserId();
                existingUser.LastUpdatedTime = _timeService.SystemTimeNow;
                await _authenticateRepo.UpdateUserAsync(existingUser);
                return true;
            }
            return false;
        }
        public async Task<bool> ActiveUserAsync(string id)
        {
            var existingUser = await _userManager.FindByIdAsync(id);
            if (existingUser != null)
            {
                existingUser.IsActive = true;
                existingUser.IsDelete = false;
                await _authenticateRepo.UpdateUserAsync(existingUser);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<UserResponse>> GetUsers()
        {
            var userList = await _authenticateRepo.GetAllUser();
            var userResponseList = _mapper.Map<IEnumerable<UserResponse>>(userList);
            return userResponseList;
        }

        public async Task<IdentityResult> ChangeUserPasswordAsync(ChangePasswordDTO request)
        {
            if (!request.ConfirmedPassword.Equals(request.NewPassword))
            {
                throw new ArgumentNullException("Mật khẩu confirm không chính xác");
            }
            var existingUser = await _userManager.FindByNameAsync(request.Username);
            if (existingUser == null)
            {
                throw new ArgumentNullException("Không tìm thấy người dùng");
            }
            if (!await _userManager.CheckPasswordAsync(existingUser, request.OldPassword))
            {
                throw new ArgumentNullException("Mật khẩu cũ không chính xác");
            }
            return await _userManager.ChangePasswordAsync(existingUser, request.OldPassword, request.NewPassword);
        }

        public async Task ForgotPassword(string email, EnvironmentType environment)
        {
            var user = await _userManager.FindByEmailAsync(email) ??
                       throw new InvalidOperationException("User not found");

            var code = new Random().Next(1000, 9999).ToString();
            var codeHash = _userManager.PasswordHasher.HashPassword(user, code);

            user.EmailCode = codeHash;
            await _userManager.UpdateAsync(user);

            var selectedEmail = new List<string> { email };

            // Create an instance of EnumExtension
            var enumExtension = new EnumExtension();

            // Get the base URL using the GetBaseUrl method
            var baseUrl = enumExtension.GetBaseUrl(environment);

            var resetUrl = $"{baseUrl}/reset-password?email={email}&code={code}";

            var emailBody = $@"
        <!DOCTYPE html>
        <html lang=""en"">
        <head>
            <meta charset=""UTF-8"">
            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
            <style>
                .button {{
                    display: inline-block;
                    padding: 10px 20px;
                    background-color: #555;
                    color: white;
                    text-decoration: none;
                    border-radius: 5px;
                    text-align: center;
                }}
                .code-box {{
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    margin: 20px 0;
                    padding: 10px;
                    border: 2px solid #000;
                    font-weight: bold;
                    font-size: 1.5em;
                    background-color: #f9f9f9;
                    border-radius: 5px;
                }}
                .content {{
                    font-family: Arial, sans-serif;
                    color: #333;
                    line-height: 1.6;
                }}
            </style>
        </head>
        <body class=""content"">
            <p>Hi {user.UserName},</p>

            <p>Forgot your password?</p>
            <p>We received a request to reset the password for your account.</p>

            <p>Your secret code is:</p>
            <div class=""code-box"">{code}</div>

            <p>To reset your password, click on the button below:</p>
            <p><a href='{resetUrl}' class='button'>Reset password</a></p>

            <p>Or copy and paste the URL into your browser:</p>
            <p><a href='{resetUrl}'>{resetUrl}</a></p>

            <p>If you didn't request this, please ignore this email.</p>
            <p>Thanks,</p>
            <p>GuYou Coffee</p>
        </body>
        </html>
    ";

            await _emailService.SendEmailAsync(selectedEmail, "Password Reset", emailBody);
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            var verificationResult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.EmailCode, request.OTP);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Invalid token." });
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, request.NewPassword);
            if (result.Succeeded)
            {
                //user.EmailCode = null; // Uncomment if you need to clear the email code
                await _userManager.UpdateAsync(user);
                var selectedEmail = new List<string> { request.Email };
                var time = _timeService.SystemTimeNow.ToString("yyyy-MM-dd HH:mm:ss");
                await _emailService.SendEmailAsync(selectedEmail, "Your password has changed", $"Your password has changed successfully at: {time}");
                return IdentityResult.Success;
            }

            return result;
        }
        public async Task<IdentityResult> VerifyOTP(string email, string otp)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            var verificationResult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.EmailCode, otp);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Invalid OTP." });
            }

            return IdentityResult.Success;
        }


    }
}
