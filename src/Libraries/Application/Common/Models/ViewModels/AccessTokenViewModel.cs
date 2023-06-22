namespace TheBloodyInn.Application.Common.Models.ViewModels;

public class AccessTokenViewModel
{
    public string? Token { get; set; }
    public string? TokenExpireAt { get; set; }

    public string? RefreshToken { get; set; }
    public string? RefreshTokenExpireAt { get; set; }
}