
public class Slot
{
    public DateTime Start { get; set; }          
    public TimeSpan Duration { get; set; }
    public Patient? BookedPatient;
    public DateTime End => Start + Duration;
}

