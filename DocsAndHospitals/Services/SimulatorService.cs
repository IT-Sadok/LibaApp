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

        public async Task RunRaceConditionSimulationAsync()
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


            var task1 = Task.Run(async () =>
            {
                Console.WriteLine("[Pat 1] trying...");
                await _appointmentManager.TryBookSlotAsync(doctor, slot, patient1);
            });

            var task2 = Task.Run(async () =>
            {
                Console.WriteLine("[Pat 2] trying...");
                await _appointmentManager.TryBookSlotAsync(doctor, slot, patient2);
            });

            await Task.WhenAll(task1, task2);

            Console.WriteLine($"Slot under patient:: {slot.BookedPatient?.Name ?? "Nobody here"}");

            await Task.Delay(1000);
        }
    }
}
