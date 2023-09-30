using VegDex.Core.Configuration;
using VegDex.Core.Utilities;

namespace VegDex.Application.Services;

public class UserService : IUserService
{
    private readonly HashingManager _hashManager;
    private readonly JwtTokenManager _jwtManager;
    private readonly IUserRepository _userRepository;
    public UserService(IConfigManager configManager, IUserRepository userRepository)
    {
        _hashManager = new HashingManager();
        _jwtManager = new JwtTokenManager(configManager);
        _userRepository = userRepository;
    }
    /// <inheritdoc/>
    public async Task<User?> GetById(int id) => await _userRepository.GetById(id);
    /// <inheritdoc/>
    public async Task<AuthenticateResponse?> AuthenticateUser(AuthenticateRequest request)
    {
        var user = await _userRepository.GetByName(request.Username);
        if (user is null) return null;

        // Validate password
        if (!_hashManager.Verify(request.Password, user.Password))
            return null;

        string token = _jwtManager.Generate(user);

        return new AuthenticateResponse(user, token);
    }
    /// <inheritdoc/>
    public Task UpdatePasswordByUserId(int userId, string password) => throw new NotImplementedException();
    /// <inheritdoc/>
    public Task<IEnumerable<User>> GetAll() => _userRepository.GetAll();
    /// <inheritdoc/>
    public async Task<AuthRegistrationResponse?> RegisterUser(AuthRegistrationRequest request)
    {
        // Ensure user with username doesn't already exist
        if (await _userRepository.GetByName(request.Username) is not null)
            return null;

        // Ensure passwords match
        if (!request.PasswordsMatch())
            return null;

        var user = await _userRepository.CreateUser(new User(request.Username,
            _hashManager.HashToString(request.Password)));
        string token = _jwtManager.Generate(user);

        return new AuthRegistrationResponse(user, token);
    }
}
