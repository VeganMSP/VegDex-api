namespace VegDex.Core.Repositories;

public interface IUserRepository
{
    Task<User?> CreateUser(User user);
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(int id);
    Task<User?> GetByName(string requestUsername);
}
