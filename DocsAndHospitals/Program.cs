namespace DocsAndHospitals
{

    
    internal class Program
    {
        private static void Main(string[] args)
        {
            Hospital[] hospitals = new Hospital[3];
            hospitals[0] = new Hospital
            {
                KNumber = 0,
                Name = "City Hospital",
                Address = "123 Main St",
                PhoneNumber = "555-1234",
                Doctors = new List<Doctor>
        {
            new Doctor { KNumber = 0, Name = "Dr. Smith", Specialization = "Cardiologist" },
            new Doctor { KNumber = 2, Name = "Dr. Brown", Specialization = "Neurologist" }
        }
            };
            hospitals[1] = new Hospital
            {
                KNumber = 1,
                Name = "County Hospital",
                Address = "456 Elm St",
                PhoneNumber = "555-5678",
                Doctors = new List<Doctor>()
            };
            hospitals[2] = new Hospital
            {
                KNumber = 2,
                Name = "State Hospital",
                Address = "789 Oak St",
                PhoneNumber = "555-9012",
                Doctors = new List<Doctor>
        {
            new Doctor { KNumber = 3, Name = "Dr. Wilson", Specialization = "Pediatrician" },
            new Doctor { KNumber = 4, Name = "Dr. Johnson", Specialization = "Orthopedic" }
        }
            };
            Menu(hospitals);
        }

        private static void Menu(Hospital[] hospitals)
        {
            Console.Clear();
            Console.WriteLine("1. Hospital's List");
            Console.WriteLine("2. Search Hospital by Id");
            Console.WriteLine("3. Exit");


            Console.WriteLine("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    HospitalList(hospitals);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Menu(hospitals);
                    break;
                case 2:
                    SearchHospital(hospitals);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Menu(hospitals);
                    break;
                case 3:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private static void HospitalList(Hospital[] hospitals)
        {
            Console.WriteLine("Hospitals:");
            foreach (var hospital in hospitals)
            {
                Console.WriteLine($"ID: {hospital.KNumber}, Name: {hospital.Name}, Address: {hospital.Address}, Phone: {hospital.PhoneNumber}");
            }
        }

        private static void SearchHospital(Hospital[] hospitals)
        {
            Console.Clear();
            Console.WriteLine("Enter ID of the hospital to search:");
            int SearchID = Convert.ToInt32(Console.ReadLine());
            var foundHosp = false;
            var foundDoc = false;
            foreach (var hospital in hospitals)
            {
                if (hospital.KNumber == SearchID)
                {
                    Console.WriteLine($"\nFound: Name: {hospital.Name}, Address: {hospital.Address}, Phone: {hospital.PhoneNumber}");
                    foundHosp = true;
                    {
                        Console.WriteLine("Doctors:");
                        foreach (var doctor in hospital.Doctors)
                        {
                            Console.WriteLine($"ID: {doctor.KNumber}, Name: {doctor.Name}, Specialization: {doctor.Specialization}");
                            foundDoc = true;
                        }
                        if (!foundDoc)
                        {
                            Console.WriteLine("No doctors found for this hospital.");
                        }
                    }
                }
            }
            if (!foundHosp)
            {
                Console.WriteLine("Hospital not found.");
                Console.ReadLine();
            }
        }

    }
}
