using System.ComponentModel.DataAnnotations;

namespace Doctor4skin.Learning.Resources;

public class SavePatientResource
{
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
