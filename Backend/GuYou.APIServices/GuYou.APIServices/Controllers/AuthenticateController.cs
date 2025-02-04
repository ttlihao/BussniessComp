using GuYou.Repositories.Configure;
using GuYou.Repositories.DTOs;
using GuYou.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GuYou.APIServices.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private readonly IAuthenticateService _authenticateService; 
        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginRequest)
        {
            var response = await _authenticateService.LoginAsync(loginRequest.UserName, loginRequest.Password);
            if (response == null) return Unauthorized();

            var token = response.VerificationToken;
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append("jwt", token, cookieOptions);

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserDTO userDTO)
        {
            var response = await _authenticateService.RegisterAsync(userDTO);
            return Ok(response);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            await _authenticateService.ForgotPassword(request.Email, EnvironmentType.Development);
            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO request)
        {
            var response = await _authenticateService.ResetPassword(request);
            return Ok(response);
        }

        [HttpPost("reset-password-link")]
        public async Task<IActionResult> ResetPasswordViaLink([FromQuery] string email, [FromQuery] string otp, [FromBody] ResetPasswordDTO request)
        {
            // Check if the email and code are provided in the query parameters
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(otp))
            {
                return BadRequest("Email and code must be provided.");
            }

            // Assign the email and code from query parameters to the DTO
            request.Email = email;
            request.OTP = otp;

            // Call the reset password service
            var response = await _authenticateService.ResetPassword(request);

            return Ok(response);
        }




    }
}
