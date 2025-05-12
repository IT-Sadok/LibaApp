namespace DocsAndHospitals
{


    internal class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine("3. Add hospital");
            Console.WriteLine("4. Update hospital by id");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice:");
            int choice = CheckCorrectId("menu");


            switch (choice)
            {
                case 1:
                    HospitalList(hospitals);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Menu(hospitals);
                    break;
                case 2:
                    Console.WriteLine("Enter ID of the hospital to search:");
                    int SearchID = CheckCorrectId();
                    SearchHospital(hospitals, SearchID);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Menu(hospitals);
                    break;
                case 3:
                    Console.Clear();
                    AddHospital(ref hospitals);
                    Console.ReadKey();
                    Menu(hospitals);
                    break;
                case 4:
                    Console.Clear();
                    UpdHospital(ref hospitals);
                    Console.ReadKey();
                    Menu(hospitals);
                    break;

                case 5:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Menu(hospitals);
                    break;
            }
        }









        private static void AddHospital(ref Hospital[] hospitals)
        {
            Console.WriteLine("Enter hospital ID:");
            int id = CheckCorrectId();
            Console.WriteLine("Enter hospital name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter hospital address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter hospital phone number:");
            string phoneNumber = Console.ReadLine();
            Array.Resize(ref hospitals, hospitals.Length + 1);
            hospitals[hospitals.Length - 1] = new Hospital
            {
                KNumber = id,
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                Doctors = new List<Doctor>()
            };
            Console.WriteLine("Hospital added successfully.");
        }

        private static int CheckCorrectId(string isitmenu = "notmenu")
        {
            int SearchID;
            var goodId = int.TryParse(Console.ReadLine(), out SearchID);
            do
            {
                if (SearchID >= 0 && goodId && isitmenu == "notmenu")
                {
                    goodId = true;
                    return SearchID;
                }
                else if (SearchID > 0 && goodId && isitmenu == "menu")
                {
                    goodId = true;
                    return SearchID;
                }
                else
                {
                    Console.WriteLine("Invalid ID. Please enter a valid number.");
                    goodId = int.TryParse(Console.ReadLine(), out SearchID);
                }
            } while (!goodId || (SearchID <= 0 && isitmenu == "menu"));
            return SearchID;    
        }


        private static int MenuUpdHospital()
        {
            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Address");
            Console.WriteLine("3. Phone Number");
            Console.WriteLine("4. Doctors");
            Console.WriteLine("5. Delete Hospital");
            Console.WriteLine("Enter your choice:");
            int updateChoice = CheckCorrectId();
            return updateChoice;
        }

        private static int MenuUpdDoctor()
        {
            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Specialization");
            Console.WriteLine("3. Delete Doctor");
            Console.WriteLine("Enter your choice:");
            int updateChoice = CheckCorrectId();
            return updateChoice;
        }

        private static void UpdHospital(ref Hospital[] hospitals)
        {
            Console.WriteLine("Enter hospital ID to update: ");
            var hospitalFound = false;
            do
            {
                int updateId = CheckCorrectId();
                SearchHospital(hospitals, updateId);
                var hospitalToUpdate = hospitals.FirstOrDefault(h => h.KNumber == updateId);
                if (hospitalToUpdate != null)
                {
                    hospitalFound = true;
                    int updateChoice = MenuUpdHospital();   
                    switch (updateChoice)
                    {
                        case 1:
                            Console.WriteLine("Enter new hospital name:");
                            hospitalToUpdate.Name = Console.ReadLine();
                            Console.WriteLine("Hospital name updated successfully.");
                            break;
                        case 2:
                            Console.WriteLine("Enter new hospital address:");
                            hospitalToUpdate.Address = Console.ReadLine();
                            Console.WriteLine("Hospital address updated successfully.");
                            break;
                        case 3:
                            Console.WriteLine("Enter new hospital phone number:");
                            hospitalToUpdate.PhoneNumber = Console.ReadLine();
                            Console.WriteLine("Hospital phone number updated successfully.");
                            break;
                        case 4:
                            var doctorFound = false;
                            do
                            {
                                Console.WriteLine("Enter the ID of the doctor to update:");
                                var doctorId = CheckCorrectId();    
                                var doctorToUpdate = hospitalToUpdate.Doctors.FirstOrDefault(d => d.KNumber == doctorId);
                                if (doctorToUpdate != null && doctorId > 0)
                                {
                                    doctorFound = true;
                                    int docUpdateChoice = MenuUpdDoctor();  
                                    switch (docUpdateChoice)
                                    {
                                        case 1:
                                            Console.WriteLine("Enter new doctor name:");
                                            doctorToUpdate.Name = Console.ReadLine();
                                            Console.WriteLine("Doctor name updated successfully.");
                                            break;
                                        case 2:
                                            Console.WriteLine("Enter new doctor specialization:");
                                            doctorToUpdate.Specialization = Console.ReadLine();
                                            Console.WriteLine("Doctor specialization updated successfully.");
                                            break;
                                        case 3:
                                            hospitalToUpdate.Doctors.Remove(doctorToUpdate);
                                            Console.WriteLine("Doctor deleted successfully.");
                                            break;
                                        default:
                                            Console.WriteLine("Invalid choice. No updates made.");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Doctor not found. Please try again.");
                                }
                            } while (!doctorFound);
                            break;
                        case 5:
                            DeleteHospital(ref hospitals, updateId);    
                            break;
                        default:
                            Console.WriteLine("Invalid choice. No updates made.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Hospital not found. Please try again.");
                }
            } while (!hospitalFound);
        }

        
        private static void DeleteHospital(ref Hospital[] hospitals, int deleteId)
        {
            Console.WriteLine("Are you sure you want to delete this hospital? (y/n)");
            string confirmDelete = Console.ReadLine();
            if (confirmDelete.ToLower() == "y")
            {
                hospitals = hospitals.Where(h => h.KNumber != deleteId).ToArray();
                Console.WriteLine("Hospital deleted successfully.");
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
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

        private static void SearchHospital(Hospital[] hospitals, int SearchID = 0)
        {
            Console.Clear();
            var foundHosp = false;
            var foundDoc = false;
            foreach (var hospital in hospitals)
            {
                if (hospital.KNumber == SearchID)
                {
                    Console.WriteLine($"\nFound:\nName: {hospital.Name}, Address: {hospital.Address}, Phone: {hospital.PhoneNumber}");
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
