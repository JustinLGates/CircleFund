using System.ComponentModel.DataAnnotations;

namespace Models
{
  public class Ticket
  {
    public string CreatorEmail { get; set; }
    public int CreatorId { get; set; }
    [Required]
    public string TestName { get; set; }
    public string PriorityLevel { get; set; }
    public string AssignedTo { get; set; }
    [Required]
    public string Setup { get; set; }
    [Required]
    public string Steps { get; set; }
    [Required]
    public string Verifications { get; set; }
    public bool Automate { get; set; }
    public string RelatedFeature { get; set; }
    public string JiraTicket { get; set; }
    public string Notes { get; set; }
    public string FilePath { get; set; }
    public string webStatus { get; set; }
    public string IosStatus { get; set; }
    public string AndroidStatus { get; set; }
    public int TicketId { get; set; }
    public int ProjectId { get; set; }


  }
}


