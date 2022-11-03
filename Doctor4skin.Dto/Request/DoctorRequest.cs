using System.ComponentModel.DataAnnotations;

namespace Doctor4skin.Dto.Request;

public class DoctorRequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MinLength(5)]
    public string Name { get; set; } = default!;

    [Required]
    public int Age { get; set; }

    public string? PhotoUrl { get; set; }
    public string Description { get; set; } = default!;
    public string Workplace { get; set; } = default!;

    [Required]
    public string Speciality { get; set; } = default!;
    public int Qualification { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    [MinLength(5)]
    public string Password { get; set; } = default!;
}
