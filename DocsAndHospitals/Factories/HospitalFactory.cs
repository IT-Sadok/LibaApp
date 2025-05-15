using DocsAndHospitals.Models;

namespace DocsAndHospitals.Factories
{
    public static class HospitalFactory
    {
        public static Hospital[] CreateMany() => new[]
        {
            new Hospital
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
            },
            new Hospital
            {
                KNumber = 1,
                Name = "County Hospital",
                Address = "456 Elm St",
                PhoneNumber = "555-5678",
                Doctors = new List<Doctor>()
            },
            new Hospital
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
            }
        };
    }
}
