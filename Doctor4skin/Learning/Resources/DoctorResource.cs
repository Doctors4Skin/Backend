namespace Doctor4skin.Learning.Resources;

public class DoctorResource
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public string? PhotoUrl { get; set; }
    public string Description { get; set; } = default!;
    public string Workplace { get; set; } = default!;
    public string Speciality { get; set; } = default!;
    public int Qualification { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
