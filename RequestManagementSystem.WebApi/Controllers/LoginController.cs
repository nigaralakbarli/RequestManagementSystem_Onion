using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Application.DTOs.Auth.Request;
using RequestManagementSystem.Application.DTOs.Auth.Response;
using RequestManagementSystem.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RequestManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(
            IAuthService authService,
            IRefreshTokenService refreshTokenService,
            IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _refreshTokenService = refreshTokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromQuery] LoginDTO loginDTO)
        {
            var tokenResponse = _authService.Login(loginDTO); 
            if (tokenResponse != null)
            {
                return Ok(tokenResponse);
            }
            return NotFound("User not found");
            
        }


        [Route("RefreshToken")]
        [HttpPost]
        public IActionResult RefreshToken([FromBody] TokenRequestDTO tokenRequestDTO)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(tokenRequestDTO.AccessToken);
            var userID = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var user = _authService.GetCurrentUserById(Convert.ToInt32(userID));

            if (user == null)
            {
                return Unauthorized();
            }

            var refreshToken = _refreshTokenService.GetByToken(tokenRequestDTO.RefreshToken);
            if (refreshToken == null || refreshToken.UserId != user.Id || !refreshToken.IsActive || refreshToken.Expires < DateTime.UtcNow)
            {
                return Unauthorized();
            }

            TokenResponseDTO response = new TokenResponseDTO()
            {
                AccessToken = _authService.GenerateAccessToken(user),
                RefreshToken = _authService.GenerateRefreshToken(user)
            };

            return Ok(response);
        }

    }
}
