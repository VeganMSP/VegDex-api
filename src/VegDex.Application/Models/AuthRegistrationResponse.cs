namespace VegDex.Application.Models;

public class AuthRegistrationResponse
{
    public AuthRegistrationResponse(User user, string token)
    {
        Id = user.Id;
        Username = user.Username;
        Token = token;
    }
    public string Token { get; set; }
    public int Id { get; set; }
    public string Username { get; set; }
}
