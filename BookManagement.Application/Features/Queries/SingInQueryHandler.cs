using BookManagement.Domain.Enitiy;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookManagement.Application.Services.Interfaces;

namespace BookManagement.Application.Features.Queries
{
    public class SignInQueryHandler(IConfiguration configuration, IUserService userService, IOtpService otpService)
        : IRequestHandler<SingInQuery, string>
    {
        private readonly IUserService _userService = userService;
        private readonly IOtpService _otpService = otpService;

        public async Task<string> Handle(SingInQuery request, CancellationToken cancellationToken)
        {
            // Step 1: Validate user credentials (username and password)
            var user = await _userService.Login(request.Username,request.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            // Step 2: Validate OTP
            var isOtpValid = await _otpService.ValidateOtpRequest(user.Id,request.Otp);

            if (!isOtpValid)
            {
                throw new UnauthorizedAccessException("Invalid OTP or OTP has expired.");
            }

            // Step 3: Generate JWT token
            var jwtToken = GenerateJwtToken(user.Username, user);

            // Return the JWT token
            return jwtToken;
        }

        private string GenerateJwtToken(string username, Users user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(ClaimTypes.Role, user.MemberShipType.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

