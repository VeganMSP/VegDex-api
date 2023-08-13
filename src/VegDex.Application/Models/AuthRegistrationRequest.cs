using System.ComponentModel.DataAnnotations;

namespace VegDex.Application.Models;

public class AuthRegistrationRequest : AuthenticateRequest
{
    [Required] public string ConfirmPassword { get; set; }
    public bool PasswordsMatch()
        => string.Equals(Password, ConfirmPassword);
}
