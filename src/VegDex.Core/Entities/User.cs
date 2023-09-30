using System.Text.Json.Serialization;

namespace VegDex.Core.Entities;

public class User
{
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
    public int Id { get; set; }
    [JsonIgnore] public string Password { get; set; }
    public string Username { get; set; }
}
