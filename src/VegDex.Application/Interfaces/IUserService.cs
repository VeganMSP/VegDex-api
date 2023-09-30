namespace VegDex.Application.Interfaces;

public interface IUserService
{
    Task<AuthenticateResponse?> AuthenticateUser(AuthenticateRequest request);
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(int id);
    Task<AuthRegistrationResponse?> RegisterUser(AuthRegistrationRequest model);
    Task UpdatePasswordByUserId(int userId, string password);
}
