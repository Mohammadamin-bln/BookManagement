using BookManagement.Application.InterFace;
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

        public SignInQueryHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> Handle(SingInQuery request, CancellationToken cancellationToken)
        {
            // Validate user credentials
            var user = await _userRepository.GetUserByCredentialsAsync(request.Username, request.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            // Get JWT settings from configuration
            var jwtSettings = _configuration.GetSection("Jwt");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new ArgumentNullException("SecretKey", "JWT Secret Key is missing in configuration.");
            }

            // Generate JWT token
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, request.Username),
        
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

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;  
        }

    }
}

