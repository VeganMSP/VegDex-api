using VegDex.Application.Interfaces;

namespace VegDex.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    /// <inheritdoc />
    public Task GetById(int id) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task AuthenticateUser(string email, string password) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task AuthenticateUserByGuid(Guid guid) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task UpdatePasswordByUserId(int userId, string password) => throw new NotImplementedException();
}
