namespace Incident.Dtos
{
    public class IncidentListDto
    {
        public int Id { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
