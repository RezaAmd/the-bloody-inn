namespace TheBloodyInn.WebApp.Models.User;

public record SignInDto(string Username, string Password, bool IsPersistent = false);