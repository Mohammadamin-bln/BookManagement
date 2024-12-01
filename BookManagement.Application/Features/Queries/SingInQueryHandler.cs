using BookManagement.Application.InterFace;
using BookManagement.Domain.Enitiy;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Features.Queries
{
    public class SignInQueryHandler : IRequestHandler<SingInQuery, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        private readonly IOtpRepository _otpRepository;

        public SignInQueryHandler(IUserRepository userRepository, IConfiguration configuration, IOtpRepository otpRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;

            _otpRepository = otpRepository;

        }

        public async Task<string> Handle(SingInQuery request, CancellationToken cancellationToken)
        {
            // Step 1: Validate user credentials (username and password)
            var user = await _userRepository.UserLoginAsync(request.Username, request.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            // Step 2: Validate OTP
            var isOtpValid = await _otpRepository.ValidateOtpForUserAsync(user.Id, request.Otp);

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

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

