using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs;

public class ContactInfo
{

    [Required]
    public string Name { get; set; }
    [Required]

    public string Email { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
}