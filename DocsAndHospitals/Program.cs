using DocsAndHospitals.Services;
using DocsAndHospitals.UI;
using DocsAndHospitals.Controllers;
using DocsAndHospitals.Persistence;
using DocsAndHospitals.Models;
using System.Globalization;

namespace DocsAndHospitals;

internal class Program
{
    static async Task Main(string[] args)
    {
        var output = new ConsoleOutput();
        var input = new ConsoleInput();
        var repository = new JsonHospitalRepository("hospitals.json");
        var service = new HospitalService(repository);
        var appointmentManager = new AppointmentManager();
        var simulation = new SimulationService(appointmentManager);

        var repo = new AuthRepository();
        var hasher = new PasswordHasher();
        var authService = new AuthService(repo, hasher);
        var authUI = new AuthUI(authService, input, output);

        var ui = new HospitalUI(service, input, output, simulation, authService, authUI);
        await ui.Run();

    }
}
