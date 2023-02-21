namespace TheBloodyInn.Application.Common.Models.ViewModels;

public class AccessTokenViewModel
{
    public string AccessToken { get; set; }
    public string AccessTokenExpiredAt { get; set; }

    public string RefreshToken { get; set; }
    public string RefreshTokenExpiredAt { get; set; }
}