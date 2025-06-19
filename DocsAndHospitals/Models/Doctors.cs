using System;
namespace DocsAndHospitals.Models;

public class Doctor
{
    public int KNumber { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public List<Slot> Slots { get; set; } = new List<Slot>();
}
