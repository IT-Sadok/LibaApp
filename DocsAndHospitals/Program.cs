using DocsAndHospitals.Services;
using DocsAndHospitals.UI;
using DocsAndHospitals.Controllers;
using DocsAndHospitals.Persistence;
using DocsAndHospitals.Models;

namespace DocsAndHospitals;

internal class Program
{
    static void Main()
    {
        var output = new ConsoleOutput();
        var input = new ConsoleInput();
        var repository = new JsonHospitalRepository("hospitals.json");
        var service = new HospitalService(repository);
        var ui = new HospitalUI(service, input, output);
        ui.Run();
    }
}
