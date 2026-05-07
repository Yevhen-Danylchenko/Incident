namespace Incident.Models
{
    public class Incident_1
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ReportedName { get; set; } = string.Empty;
        public string ReportedEmail { get; set;} = string.Empty;
        public string AssignedTo { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
