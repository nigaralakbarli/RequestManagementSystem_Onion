namespace RequestManagementSystem.Application.DTOs.Auth.Response;

public class TokenResponseDTO
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
