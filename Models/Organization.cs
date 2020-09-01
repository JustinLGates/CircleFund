using System.ComponentModel.DataAnnotations;

namespace Models
{
  public class Organization
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string LogoUrl { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Address { get; set; }
    public int Id { get; set; }
  }
}





