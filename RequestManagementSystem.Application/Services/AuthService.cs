using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RequestManagementSystem.Application.DTOs.Auth.Request;
using RequestManagementSystem.Application.DTOs.Auth.Response;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RequestManagementSystem.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;

        public AuthService(
            IUserRepository userRepository, 
            IHttpContextAccessor httpContextAccessor,
            IRefreshTokenService refreshTokenService,
            IConfiguration config)
        {
            _config = config;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _refreshTokenService = refreshTokenService;
        }

        public User Authenticate(LoginDTO loginDTO)
        {
            var currentUser = _userRepository.Find(u => u.Name.ToLower() == loginDTO.Name.ToLower() && u.Password == loginDTO.Password).FirstOrDefault();

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        public string GenerateAccessToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(20),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken(User user)
        {
            var userId = user.Id;

            var refreshToken = _refreshTokenService.GetByUserId(userId);

            if (refreshToken == null || !refreshToken.IsActive || refreshToken.Expires < DateTime.UtcNow)
            {
                if (refreshToken != null)
                {
                    refreshToken.IsActive = false;
                    _refreshTokenService.Update(refreshToken);
                }

                refreshToken = new RefreshToken
                {
                    UserId = userId,
                    Token = Guid.NewGuid().ToString(),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    IsActive = true
                };

                _refreshTokenService.Add(refreshToken);
            }

            return refreshToken.Token;
        }

        public User GetCurrentUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userRepository.Find(o => o.Id.ToString().ToLower() == userId.ToLower()).FirstOrDefault();
        }

        public User GetCurrentUserById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public TokenResponseDTO Login(LoginDTO loginDTO)
        {
            var user = Authenticate(loginDTO);
            if (user != null)
            {
                TokenResponseDTO response = new TokenResponseDTO()
                {
                    AccessToken = GenerateAccessToken(user),
                    RefreshToken = GenerateRefreshToken(user)
                };
                return response;
            }
            return null;
        }

        public string ChangePassword(string oldPassword, string newPassword, string repeatedPassword)
        {
            var user = GetCurrentUser();
            string pattern = "^(?=.*[A-Z])(?=.*\\W).{8,}$";

            if (user.Password == oldPassword)
            {
                if (Regex.IsMatch(newPassword, pattern))
                {
                    if (newPassword == repeatedPassword)
                    {
                        user.Password = newPassword;
                        _userRepository.Update(user);
                        return "Password updated successfully";
                    }
                    else
                    {
                        return "Repeated password doesn't match with new password";
                    }

                }
                else
                {
                    return "Password must be at least 8 characters long, contain at least one uppercase letter, and one special character.";
                }
            }
            else
            {
                return "Incorrect old password";
            }
        }
    }
}
