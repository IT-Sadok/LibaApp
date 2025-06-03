using DocsAndHospitals.Models;
using DocsAndHospitals.Services;
using DocsAndHospitals.UI;

namespace DocsAndHospitals.Controllers
{
    public class HospitalUI
    {
        private readonly HospitalService _service;
        private readonly IInput _input;
        private readonly IOutput _output;

        public HospitalUI(HospitalService service, IInput input, IOutput output)
        {
            _service = service;
            _input = input;
            _output = output;
        }


        public void Run()
        {
            int mainchoice;
            do
            {
                _output.Clear();
                _output.WriteLine("1. List Hospitals");
                _output.WriteLine("2. Search Hospital");
                _output.WriteLine("3. Add Hospital");
                _output.WriteLine("4. Update Hospital");
                _output.WriteLine("5. Save Changes");
                _output.WriteLine("0. Exit");
                _output.Write("Choice: ");
                mainchoice = _input.ReadInt();

                _output.Clear();
                switch (mainchoice)
                {
                    case 1:
                        ShowAllHospitals();
                        break;
                    case 2:
                        _output.Write("Enter ID: ");
                        int id = _input.ReadInt();
                        var hospital = _service.GetHospitalById(id);
                        if (hospital != null)
                        {
                            DisplayHospitalWithDoctors(hospital);
                            _output.PressKey();
                        }
                        else
                        {
                            _output.WriteLine("Hospital not found.");
                            _output.PressKey();
                        }
                        break;
                    case 3:
                        AddHospital();
                        break;
                    case 4:
                        UpdateHospital();
                        break;
                    case 5:
                        _service.Save();
                        _output.WriteLine("Changes saved.");
                        _output.PressKey();
                        break;
                }

            } while (mainchoice != 0);

            _output.WriteLine("Bye!");
        }

        public void ShowAllHospitals()
        {
            var hospitals = _service.GetAllHospitals();
            foreach (var h in hospitals)
                _output.WriteLine($"ID: {h.KNumber}, Name: {h.Name}, Address: {h.Address}, Phone: {h.PhoneNumber}");
            _output.PressKey();
        }


        public void DisplayHospitalWithDoctors(Hospital hospital)
        {
            _output.WriteLine($"ID: {hospital.KNumber}, Name: {hospital.Name}, Address: {hospital.Address}, Phone: {hospital.PhoneNumber}");

            if (hospital.Doctors.Any())
            {
                _output.WriteLine("\nDoctors:");
                foreach (var doc in hospital.Doctors)
                {
                    _output.WriteLine($"  ID: {doc.KNumber}, Name: {doc.Name}, Specialization: {doc.Specialization}");
                }
            }
            else
            {
                _output.WriteLine("\nNo doctors assigned to this hospital.");
            }
        }


        public void AddHospital()
        {
            _output.Write("Enter hospital ID: ");
            int id = _input.ReadInt();
            _output.Write("Name: ");
            string name = _input.ReadLine();
            _output.Write("Address: ");
            string address = _input.ReadLine();
            _output.Write("Phone: ");
            string phone = _input.ReadLine();

            _service.AddHospital(new Hospital
            {
                KNumber = id,
                Name = name,
                Address = address,
                PhoneNumber = phone
            });

            _output.WriteLine("Hospital added.");
            _output.PressKey();
        }

        public void UpdateHospital()
        {
            _output.Write("Enter hospital ID to update: ");
            int id = _input.ReadInt();
            var hospital = _service.GetHospitalById(id);
            if (hospital != null)
            {
                DisplayHospitalWithDoctors(hospital);
                _output.PressKey();

                int choice;
                do
                {
                    _output.WriteLine("\nUpdate Hospital:");
                    _output.WriteLine("1. Name");
                    _output.WriteLine("2. Address");
                    _output.WriteLine("3. Phone Number");
                    _output.WriteLine("4. Manage Doctors");
                    _output.WriteLine("5. Delete Hospital");
                    _output.WriteLine("0. Back");
                    choice = _input.ReadInt();

                    switch (choice)
                    {
                        case 1:
                            _output.Write("New name: ");
                            _service.UpdateHospital(hospital, name: _input.ReadLine());
                            break;
                        case 2:
                            _output.Write("New address: ");
                            _service.UpdateHospital(hospital, address: _input.ReadLine());
                            break;
                        case 3:
                            _output.Write("New phone: ");
                            _service.UpdateHospital(hospital, phone: _input.ReadLine());
                            break;
                        case 4:
                            ManageDoctors(hospital);
                            break;
                        case 5:
                            _service.DeleteHospital(id);
                            _output.WriteLine("Hospital deleted.");
                            return;
                    }
                } while (choice != 0);
            }
            else
            {
                _output.WriteLine("Hospital not found.");
                _output.PressKey();
            }

           
            _output.PressKey();
        }

        private void ManageDoctors(Hospital hospital)
        {
            int choice;
            do
            {
                _output.WriteLine("\nDoctor Management:");
                _output.WriteLine("1. Add Doctor");
                _output.WriteLine("2. Update Doctor");
                _output.WriteLine("3. Delete Doctor");
                _output.WriteLine("0. Back");
                choice = _input.ReadInt();

                switch (choice)
                {
                    case 1:
                        _output.Write("Doctor ID: ");
                        int id = _input.ReadInt();
                        _output.Write("Name: ");
                        string name = _input.ReadLine();
                        _output.Write("Specialization: ");
                        string spec = _input.ReadLine();
                        _service.AddDoctor(hospital, new Doctor { KNumber = id, Name = name, Specialization = spec });
                        _output.WriteLine("Doctor added!");
                        _output.PressKey();
                        break;

                    case 2:
                        _output.Write("Doctor ID to update: ");
                        int did = _input.ReadInt();
                        var doc = _service.GetDoctor(hospital, did);
                        if (doc != null)
                        {
                            _output.WriteLine("1. Name\n2. Specialization");
                            int upd = _input.ReadInt();
                            if (upd == 1)
                            {
                                _output.Write("New Name: ");
                                _service.UpdateDoctor(doc, name: _input.ReadLine());
                            }
                            else if (upd == 2)
                            {
                                _output.Write("New Specialization: ");
                                _service.UpdateDoctor(doc, specialization: _input.ReadLine());
                            }
                        }
                        else
                        {
                            _output.WriteLine("Doctor not found.");
                        }
                        break;

                    case 3:
                        _output.Write("Doctor ID to delete: ");
                        int delId = _input.ReadInt();
                        _service.DeleteDoctor(hospital, delId);
                        _output.WriteLine("Doctor deleted.");
                        _output.PressKey();
                        break;
                }
            } while (choice != 0);
        }
    }
}
