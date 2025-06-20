using DocsAndHospitals.Models;
public class AuthService
{
    private readonly AuthRepository _repo;
    private readonly PasswordHasher _hasher;

    public AuthService(AuthRepository repo, PasswordHasher hasher)
    {
        _repo = repo;
        _hasher = hasher;
    }

    public bool Rerister(RegisterRequest request)
    {
        if (_repo.GetByEmail(request.Email) != null)
            return false;

        var user = new User
        {
            Email = request.Email,
            PasswordHash = _hasher.Hash(request.Password),
            Role = request.Role
        };

        _repo.AddUser(user);
        return true;
    }

    public User? Login(LoginRequest request)
    {

        var user = _repo.GetByEmail(request.Email);
        if (user == null || !_hasher.Verify(user.PasswordHash, request.Password))
            return null;

        return user;
    }

}
