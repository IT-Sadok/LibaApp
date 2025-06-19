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
        var ui = new HospitalUI(service, input, output, simulation);
        await ui.Run();
    }
}
