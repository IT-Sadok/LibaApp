using DocsAndHospitals.Models;
using System.Globalization;

public class AppointmentManager
{
    private readonly object _lock = new();

    public bool TryBookSlot(Doctor doctor, Slot slot, Patient patient)
    {
        lock (_lock)
        {
            Thread.Sleep(200);
            if (slot.BookedPatient == null)
            {
                slot.BookedPatient = patient;
                Console.WriteLine($" {patient.Name} get slot {slot.Start.Day} {slot.Start.ToString("MMMM", new CultureInfo("en-US"))} {slot.Start.Year}, time: {slot.Start.TimeOfDay}");
                return true;
            }

            Console.WriteLine($" {patient.Name} mistake. slot unavalible");
            return false;
        }
    }
}
