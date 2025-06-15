using DocsAndHospitals.Models;
using System;
using System.Threading;

namespace DocsAndHospitals.Services
{
    public class SimulationService
    {
        private readonly AppointmentManager _appointmentManager;

        public SimulationService(AppointmentManager appointmentManager)
        {
            _appointmentManager = appointmentManager;
        }

        public void RunRaceConditionSimulation()
        {
            Console.WriteLine("=== Simulation ===");

            var patient1 = new Patient { Name = "Patient 1" };
            var patient2 = new Patient { Name = "Patient 2" };

            var doctor = new Doctor
            {
                KNumber = 1,
                Name = "Doc X",
                Specialization = "Terapeut",
                Slots = new List<Slot>
                {
                    new Slot
                    {
                        Start = new DateTime(2025, 6, 9, 10, 0, 0), 
                        Duration = TimeSpan.FromMinutes(30),
                        BookedPatient = null
                    }
                }
            };

            var slot = doctor.Slots[0];


            var thread1 = new Thread(() =>
            {
                Console.WriteLine("[Pat 1] trying...");
                _appointmentManager.TryBookSlot(doctor, slot, patient1);
            });

            var thread2 = new Thread(() =>
            {
                Console.WriteLine("[Pat 2] trying...");
                _appointmentManager.TryBookSlot(doctor, slot, patient2);
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Slot under patient:: {slot.BookedPatient.Name ?? "Nobody here"}");
            Thread.Sleep(1000);
        }
    }
}
