namespace VegDex.Application.Interfaces;

public interface IUserService
{
    Task<AuthenticateResponse> AuthenticateUser(AuthenticateRequest request);
    Task<User?> GetById(int id);
    Task UpdatePasswordByUserId(int userId, string password);
    Task<IEnumerable<User>> GetAll();
}
