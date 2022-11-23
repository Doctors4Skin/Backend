namespace Doctor4skin.Learning.Domain.Models;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public string? PhotoUrl { get; set; }
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
