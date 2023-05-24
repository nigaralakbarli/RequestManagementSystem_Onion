namespace RequestManagementSystem.Application.DTOs.Auth.Request;

public class TokenRequestDTO
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
