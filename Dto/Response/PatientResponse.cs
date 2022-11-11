namespace Dto.Response;

public class PatientResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public string? PhotoUrl { get; set; }
    public string Email { get; set; } = default!;
}
