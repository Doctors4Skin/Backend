namespace Doctor4skin.Learning.Domain.Models;

public class Reservation
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string MeetUrl { get; set; } = default!;
    public string MeetDate { get; set; } = default!;
    public string Status { get; set; } = default!;

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = default!;

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = default!; 
}
