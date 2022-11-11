using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dto.Request;

public class DoctorRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    [Required]
    public int Age { get; set; } = default!;

    public string? PhotoUrl { get; set; }
    public string? Description { get; set; }

    [Required]
    [MaxLength(250)]
    public string Workplace { get; set; } = default!;

    [Required]
    [MaxLength(250)]
    public string Speciality { get; set; } = default!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}
