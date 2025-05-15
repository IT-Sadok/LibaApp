using DocsAndHospitals.Models;
using DocsAndHospitals.Services;
using DocsAndHospitals.UI;
using DocsAndHospitals.Factories;

namespace DocsAndHospitals;

internal class Program
{
    static void Main()
    {
        Hospital[] hospitals = HospitalFactory.CreateMany();
        MainMenu(hospitals);
    }

    private static void MainMenu(Hospital[] hospitals)
    {
        IOutput output = new ConsoleOutput();
        IInput input = new ConsoleInput();
        var service = new HospitalService(output, input);
        int mainchoice = 0;
        do
        {
            output.Clear();
            output.WriteLine("1. List Hospitals");
            output.WriteLine("2. Search Hospital");
            output.WriteLine("3. Add Hospital");
            output.WriteLine("4. Update Hospital");
            output.WriteLine("0. Exit");
            output.Write("Choice: ");
            mainchoice = input.ReadInt();

            output.Clear();
            switch (mainchoice)
            {
                case 1:
                    service.DisplayHospitals(hospitals);
                    break;
                case 2:
                    output.Write("Enter ID: ");
                    int id = input.ReadInt();
                    service.SearchHospital(hospitals, id);
                    break;
                case 3:
                    service.AddHospital(ref hospitals);
                    break;
                case 4:
                    service.UpdateHospital(ref hospitals);
                    break;
            }

        } while (mainchoice != 0);

        output.WriteLine("Bye!");
    }
}

  