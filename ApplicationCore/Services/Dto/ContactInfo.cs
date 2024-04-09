using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Interfaces.TodoService.Dto;

public class ContactInfo
{
    
    [Required]
    public string Name { get; set; }
    [Required]
    
    public string Email { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
}