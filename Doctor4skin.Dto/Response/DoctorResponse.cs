namespace Doctor4skin.Dto.Response;

public class DoctorResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public string? PhotoUrl { get; set; }
    public string Description { get; set; } = default!;
    public int Qualification { get; set; } = default!;
}
