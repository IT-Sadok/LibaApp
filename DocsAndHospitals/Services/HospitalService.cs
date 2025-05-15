using DocsAndHospitals.Models;
using System;
using System.Linq;
using DocsAndHospitals.UI;

namespace DocsAndHospitals.Services
{
    public class HospitalService
    {
        private readonly IOutput _output;
        private readonly IInput _input;

        public HospitalService(IOutput output, IInput input)
        {
            _output = output;
            _input = input;
        }

        public void DisplayHospitals(Hospital[] hospitals)
        {
            foreach (var h in hospitals)
                _output.WriteLine($"ID: {h.KNumber}, Name: {h.Name}, Address: {h.Address}, Phone: {h.PhoneNumber}");
            _output.PressKey(); 
        }

        public void SearchHospital(Hospital[] hospitals, int id)
        {
            var hospital = hospitals.FirstOrDefault(h => h.KNumber == id);
            if (hospital == null)
            {
                _output.WriteLine("Hospital not found.");
                _output.PressKey();
                return;
            }

            _output.Clear();
            _output.WriteLine($"Found hospital: \n{hospital.Name}, Address: {hospital.Address}, Phone: {hospital.PhoneNumber}");

            if (hospital.Doctors.Any())
            {
                _output.WriteLine("Doctors:");
                foreach (var doc in hospital.Doctors)
                    _output.WriteLine($"ID: {doc.KNumber}, Name: {doc.Name}, Specialization: {doc.Specialization}");
            }
            else _output.WriteLine("No doctors in this hospital.");

            _output.PressKey();
        }


        public void AddHospital(ref Hospital[] hospitals)
        {
            _output.Write("Enter hospital ID: ");
            int id = _input.ReadInt();
            _output.Write("Name: ");
            string name = _input.ReadLine();
            _output.Write("Address: ");
            string address = _input.ReadLine();
            _output.Write("Phone: ");
            string phone = _input.ReadLine();
            Array.Resize(ref hospitals, hospitals.Length + 1);
            hospitals[^1] = new Hospital { KNumber = id, Name = name, Address = address, PhoneNumber = phone };
            _output.WriteLine("Hospital added.");
            _output.PressKey();  
        }

        public void UpdateHospital(ref Hospital[] hospitals)
        {
            _output.Write("Enter hospital ID to update: ");
            int id = _input.ReadInt();

            var hospital = hospitals.FirstOrDefault(h => h.KNumber == id);
            if (hospital == null)
            {
                _output.WriteLine("Hospital not found.");
                return;
            }

            int choice;
            do
            {
                SearchHospital(hospitals, id);
                _output.WriteLine("\nUpdate:");
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
                        hospital.Name = _input.ReadLine();
                        _output.Clear();
                        break;
                    case 2:
                        _output.Write("New address: ");
                        hospital.Address = _input.ReadLine();
                        _output.Clear();
                        break;
                    case 3:
                        _output.Write("New phone: ");
                        hospital.PhoneNumber = _input.ReadLine();
                        _output.Clear();
                        break;
                    case 4:
                        ManageDoctors(hospital);
                        break;
                    case 5:
                        hospitals = hospitals.Where(h => h.KNumber != id).ToArray();
                        _output.WriteLine("Hospital deleted.");
                        return;
                }
            } while (choice != 0);
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
                        hospital.Doctors.Add(new Doctor { KNumber = id, Name = name, Specialization = spec });
                        _output.Write("Doctor added!");
                        _output.PressKey();
                        _output.Clear();
                        break;
                    case 2:
                        _output.Write("Doctor ID to update: ");
                        int did = _input.ReadInt();
                        var doc = hospital.Doctors.FirstOrDefault(d => d.KNumber == did);
                        if (doc != null)
                        {
                            _output.WriteLine("1. Name\n2. Specialization");
                            int upd = _input.ReadInt();
                            if (upd == 1)
                            {
                                _output.Write("New Name: ");
                                doc.Name = _input.ReadLine();
                                _output.WriteLine("Doctor updated.");
                                _output.PressKey();
                            }
                            else if (upd == 2)
                            {
                                _output.Write("New Specialization: ");
                                doc.Specialization = _input.ReadLine();
                            }
                        }
                        else _output.WriteLine("Doctor not found.");
                        break;
                    case 3:
                        _output.Write("Doctor ID to delete: ");
                        int delId = _input.ReadInt();
                        hospital.Doctors.RemoveAll(d => d.KNumber == delId);
                        _output.WriteLine("Doctor deleted.");
                        _output.PressKey();
                        break;
                }
            } while (choice != 0);
        }

        
    }
}
