using System.ComponentModel.DataAnnotations;

namespace Dto.Request;

public class PatientRequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public int Name { get; set; }

    [Required]
    public int Age { get; set; }    
    public string? PhotoUrl { get; set; }

    [Required]
    public string Email { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}
