
public class Slot
{
    public DateTime Start { get; set; }          
    public TimeSpan Duration { get; set; }       
    public Patient? BookedPatient { get; set; }  
    public DateTime End => Start + Duration;
}
