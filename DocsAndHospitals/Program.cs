namespace DocsAndHospitals
{

    public class Doctor
    {
        public int KNumber { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public Doctor(int knumber, string name, string specialization)
        {
            KNumber = knumber;
            Name = name;
            Specialization = specialization;
        }
    }
    class Hospital
    {
        public int KNumber { get; set; }    
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Doctor> Doctors { get; set; }
        public Hospital(int knumber, string name, string address, string phoneNumber)
        {
            KNumber = knumber;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Doctors = new List<Doctor>();
        }
    }
    internal class Program
    {
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Hospital's List");
            Console.WriteLine("2. Search Hospital by Id");
            Console.WriteLine("3. Exit");
        }

        static void HospitalList(Hospital[] hospitals)
        {
            Console.WriteLine("Hospitals:");
            foreach (var hospital in hospitals)
            {
                Console.WriteLine($"ID: {hospital.KNumber}, Name: {hospital.Name}, Address: {hospital.Address}, Phone: {hospital.PhoneNumber}");
            }
        }

        static void SearchHospital(Hospital[] hospitals)
        {
            Console.Clear();    
            Console.WriteLine("Enter ID of the hospital to search:");
            int SearchID = Convert.ToInt32(Console.ReadLine());
            bool foundHosp = false;
            bool foundDoc = false;  
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

        static void Main(string[] args)
        {
            Hospital[] hospitals = new Hospital[3];
            hospitals[0] = new Hospital(0, "City Hospital", "123 Main St", "555-1234");
            hospitals[0].Doctors.Add(new Doctor(0, "Dr. Smith", "Cardiologist"));
            hospitals[0].Doctors.Add(new Doctor(2, "Dr. Brown", "Neurologist"));
            hospitals[1] = new Hospital(1, "County Hospital", "456 Elm St", "555-5678");
            hospitals[2] = new Hospital(2, "State Hospital", "789 Oak St", "555-9012");
            hospitals[2].Doctors.Add(new Doctor(3, "Dr. Wilson", "Pediatrician"));
            hospitals[2].Doctors.Add(new Doctor(4, "Dr. Johnson", "Orthopedic"));
        again:
            Menu();
            Console.WriteLine("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    HospitalList(hospitals);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(); 
                    goto again;
                case 2:
                    SearchHospital(hospitals);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(); 
                    goto again;
                case 3:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
       

        }
    }
}
