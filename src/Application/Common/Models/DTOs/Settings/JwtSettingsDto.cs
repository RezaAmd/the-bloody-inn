namespace TheBloodyInn.Application.Common.Models.DTOs.Settings;

public class JwtSettingsDto
{
    public string SecretKey { get; set; }
    public string EncryptKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int? ExpirationMinutes { get; set; }
}
