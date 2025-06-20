using DocsAndHospitals.Models;
using DocsAndHospitals.Services;
using DocsAndHospitals.UI;
using DocsAndHospitals.Persistence;
using FluentValidation;

public class AuthUI
{
    private readonly AuthService _auth;
    private readonly IInput _input;
    private readonly IOutput _output;

    public AuthUI(AuthService auth, IInput input, IOutput output)
    {
        _auth = auth;
        _input = input;
        _output = output;
    }

    public bool Register()
    {
        _output.Write("Email: ");
        var email = _input.ReadLine();

        _output.Write("Password: ");
        var password = _input.ReadLine();

        _output.Write("Confirm Password: ");
        var confirm = _input.ReadLine();

        _output.Write("Role (0=Client, 1=Doctor): ");
        var role = (Role)_input.ReadInt();

        var request = new RegisterRequest
        {
            Email = email,
            Password = password,
            ConfirmPassword = confirm,
            Role = role
        };



        var validator = new RegisterValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
                _output.WriteLine(error.ErrorMessage);
            return false;
        }

        if (_auth.Rerister(request))
            _output.WriteLine("Registration successful!");
        else
        {
            _output.WriteLine("User already exists.");
            return false;
        }
        return false;
    }

    public bool Login()
    {
        _output.Write("Email: ");
        var email = _input.ReadLine();

        _output.Write("Password: ");
        var password = _input.ReadLine();

  

        var request = new LoginRequest
        {
            Email = email,
            Password = password
        };

        var user = _auth.Login(request);
        if (user != null)
        {
            _output.WriteLine($"Login success! Role: {user.Role}");
            return true;
        }
        else
            _output.WriteLine("Invalid credentials.");
        return false;
    }
}
