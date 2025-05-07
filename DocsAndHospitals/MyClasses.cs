using System;

public class Doctor
{
    public int KNumber { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
}
class Hospital
{
    public int KNumber { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public List<Doctor> Doctors { get; set; }
}