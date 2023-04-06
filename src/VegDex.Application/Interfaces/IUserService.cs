namespace VegDex.Application.Interfaces;

public interface IUserService
{
    Task GetById(int id);
    Task AuthenticateUser(string email, string password);
    Task AuthenticateUserByGuid(Guid guid);
    Task UpdatePasswordByUserId(int userId, string password);
}
