using DocsAndHospitals.Services;
using DocsAndHospitals.UI;
using DocsAndHospitals.Controllers;

namespace DocsAndHospitals;

internal class Program
{
    static void Main()
    {
        var output = new ConsoleOutput();
        var input = new ConsoleInput();
        var service = new HospitalService();
        var ui = new HospitalUI(service, input, output);
        ui.Run();
    }
}
