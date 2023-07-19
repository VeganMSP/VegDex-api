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
    public async Task<User?> GetById(int id) => await _userRepository.GetById(id);
    /// <inheritdoc />
    public Task<AuthenticateResponse> AuthenticateUser(AuthenticateRequest request) =>
        throw new NotImplementedException();
    /// <inheritdoc />
    public Task UpdatePasswordByUserId(int userId, string password) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<IEnumerable<User>> GetAll()
    {
        return _userRepository.GetAll();
    }
}
