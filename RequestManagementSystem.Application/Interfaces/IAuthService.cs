using RequestManagementSystem.Application.DTOs.Auth.Request;
using RequestManagementSystem.Application.DTOs.Auth.Response;
using RequestManagementSystem.Domain.Entities;

namespace RequestManagementSystem.Application.Interfaces
{
    public interface IAuthService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken(User user);
        public User GetCurrentUser();
        public User GetCurrentUserById(int userId);
        User Authenticate(LoginDTO loginDTO);
        TokenResponseDTO Login(LoginDTO loginDTO);
    }
}
