using DocsAndHospitals.Models;
using System;
namespace DocsAndHospitals.Services;

public class HospitalService
{
    public void DisplayHospitals(Hospital[] hospitals)
    {
        foreach (var h in hospitals)
            Console.WriteLine($"ID: {h.KNumber}, Name: {h.Name}, Address: {h.Address}, Phone: {h.PhoneNumber}");
    }

    public void SearchHospital(Hospital[] hospitals, int id)
    {
        var hospital = hospitals.FirstOrDefault(h => h.KNumber == id);
        if (hospital == null)
        {
            Console.WriteLine("Hospital not found.");
            return;
        }
        Console.Clear();    
        Console.WriteLine($"Found hospital: \n{hospital.Name}, Address: {hospital.Address}, Phone: {hospital.PhoneNumber}");

        if (hospital.Doctors.Any())
        {
            Console.WriteLine("Doctors:");
            foreach (var doc in hospital.Doctors)
                Console.WriteLine($"ID: {doc.KNumber}, Name: {doc.Name}, Specialization: {doc.Specialization}\n");
        }
        else Console.WriteLine("No doctors in this hospital.");
    }

    public void AddHospital(ref Hospital[] hospitals)
    {
        Console.Write("Enter hospital ID: ");
        int id = ReadInt();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Address: ");
        string address = Console.ReadLine();
        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Array.Resize(ref hospitals, hospitals.Length + 1);
        hospitals[^1] = new Hospital { KNumber = id, Name = name, Address = address, PhoneNumber = phone };
        Console.WriteLine("Hospital added.");

    }

    public void UpdateHospital(ref Hospital[] hospitals)
    {
        Console.Write("Enter hospital ID to update: ");
        int id = ReadInt();

        var hospital = hospitals.FirstOrDefault(h => h.KNumber == id);
        if (hospital == null)
        {
            Console.WriteLine("Hospital not found.");
            return;
        }
        
        int choice;
        do
        {
            var service = new HospitalService();
            service.SearchHospital(hospitals, id);
            Console.WriteLine("\nUpdate:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Address");
            Console.WriteLine("3. Phone Number");
            Console.WriteLine("4. Manage Doctors");
            Console.WriteLine("5. Delete Hospital");
            Console.WriteLine("0. Back");
            choice = ReadInt();

            switch (choice)
            {
                case 1:
                    Console.Write("New name: ");
                    hospital.Name = Console.ReadLine();
                    Console.Clear();
                    break;
                case 2:
                    Console.Write("New address: ");
                    hospital.Address = Console.ReadLine();
                    Console.Clear();
                    break;
                case 3:
                    Console.Write("New phone: ");
                    hospital.PhoneNumber = Console.ReadLine();
                    Console.Clear();
                    break;
                case 4:
                    ManageDoctors(hospital);
                    break;
                case 5:
                    hospitals = hospitals.Where(h => h.KNumber != id).ToArray();
                    Console.WriteLine("Hospital deleted.");
                    return;
            }
        } while (choice != 0);
 
    }

    private void ManageDoctors(Hospital hospital)
    {
        int choice;
        do
        {
            Console.WriteLine("\nDoctor Management:");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Update Doctor");
            Console.WriteLine("3. Delete Doctor");
            Console.WriteLine("0. Back");
            choice = ReadInt();

            switch (choice)
            {
                case 1:
                    Console.Write("Doctor ID: ");
                    int id = ReadInt();
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Specialization: ");
                    string spec = Console.ReadLine();
                    hospital.Doctors.Add(new Doctor { KNumber = id, Name = name, Specialization = spec });
                    Console.Write("Doctor added!");
                    Console.Clear();
                    break;
                case 2:
                    Console.Write("Doctor ID to update: ");
                    int did = ReadInt();
                    var doc = hospital.Doctors.FirstOrDefault(d => d.KNumber == did);
                    if (doc != null)
                    {
                        Console.WriteLine("1. Name\n2. Specialization");
                        int upd = ReadInt();
                        if (upd == 1)
                        {
                            Console.Write("New Name: ");
                            doc.Name = Console.ReadLine();
                        }
                        else if (upd == 2)
                        {
                            Console.Write("New Specialization: ");
                            doc.Specialization = Console.ReadLine();
                        }
                    }
                    else Console.WriteLine("Doctor not found.");
                    break;
                case 3:
                    Console.Write("Doctor ID to delete: ");
                    int delId = ReadInt();
                    hospital.Doctors.RemoveAll(d => d.KNumber == delId);
                    Console.WriteLine("Doctor deleted.");
                    break;
            }
        } while (choice != 0);
    }

    public static int ReadInt()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
            Console.Write("Enter a valid positive number: ");
        return value;
    }

    public void MainMenu(ref Hospital[] hospitals)
    {
        

        int mainchoice = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("1. List Hospitals");
            Console.WriteLine("2. Search Hospital");
            Console.WriteLine("3. Add Hospital");
            Console.WriteLine("4. Update Hospital");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");
            mainchoice = ReadInt();

            Console.Clear();
            switch (mainchoice)
            {
                case 1:
                    DisplayHospitals(hospitals);
                    break;
                case 2:
                    Console.Write("Enter ID: ");
                    int id = HospitalService.ReadInt();
                    SearchHospital(hospitals, id);
                    break;
                case 3:
                    AddHospital(ref hospitals);
                    break;
                case 4:
                    UpdateHospital(ref hospitals);
                    break;
            }

        } while (mainchoice != 0);

        Console.WriteLine("Bye!");
    }
}
