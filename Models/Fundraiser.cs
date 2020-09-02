using System.ComponentModel.DataAnnotations;

namespace Models
{
  public class Fundraiser
  {
    public int Id { get; set; }
    public bool Active { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Goal { get; set; }
    public string CurrentAmount { get; set; }
    public string Link { get; set; }
    public int organizationId { get; set; }
  }
}