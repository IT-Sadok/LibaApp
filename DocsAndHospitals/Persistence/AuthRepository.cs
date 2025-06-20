using DocsAndHospitals.Models;

public class AuthRepository
{
    private readonly List<User> _users = new();

    public AuthRepository()
    {
        var hasher = new PasswordHasher();
        string hashedPassword = hasher.Hash("111");

        _users.Add(new User
        {
            Id = 1,
            Email = "user",
            PasswordHash = hashedPassword,
            Role = Role.Client
        });
    }

    public void AddUser(User user) => _users.Add(user);

    public User? GetByEmail(string email) => _users.FirstOrDefault(x => x.Email == email);
}
