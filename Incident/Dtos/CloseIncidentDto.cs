namespace Incident.Dtos
{
    public class CloseIncidentDto
    {
        public int Id { get; set; }
        public string ClosingComment { get; set; } = string.Empty;
        public DateTime ClosedAt { get; set; } = DateTime.Now;
    }
}
