
using System.ComponentModel.DataAnnotations;

namespace Models
{
  public class Message
  {
    [Required]
    public string Body { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Id { get; set; }
  }
}