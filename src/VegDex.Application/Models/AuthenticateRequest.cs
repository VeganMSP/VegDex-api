using System.ComponentModel.DataAnnotations;

namespace VegDex.Application.Models;

public class AuthenticateRequest
{
    [Required] public string Password { get; set; }
    [Required] public string Username { get; set; }
}
