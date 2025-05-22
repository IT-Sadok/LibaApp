using DocsAndHospitals.Services;
using DocsAndHospitals.UI;
using DocsAndHospitals.Controllers;
using DocsAndHospitals.Factories; 

namespace DocsAndHospitals;

internal class Program
{
    static void Main()
    {
        var output = new ConsoleOutput();
        var input = new ConsoleInput();
        var factory = new HospitalFactory();           
        var service = new HospitalService(factory);         
        var ui = new HospitalUI(service, input, output);
        ui.Run();
    }
}
