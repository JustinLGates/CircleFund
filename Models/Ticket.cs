using System.ComponentModel.DataAnnotations;

namespace Models
{
  public class Ticket
  {
    [Required]
    public string creatorEmail { get; set; }
    [Required]
    public string testName { get; set; }
    public string priorityLevel { get; set; }
    [Required]
    public string assignedTo { get; set; }
    [Required]
    public string setup { get; set; }
    [Required]
    public string steps { get; set; }
    [Required]
    public string verifications { get; set; }
    public bool automate { get; set; }
    public string relatedFeature { get; set; }
    public string jiraticket { get; set; }
    public string notes { get; set; }
    public string filepath { get; set; }
    public string webStatus { get; set; }
    public string iosStatus { get; set; }
    public string androidStatus { get; set; }
    public int Id { get; set; }
    public int ProjectId { get; set; }

  }
}


