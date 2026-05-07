namespace Incident.Dtos
{
    public class AssignIncidentDto
    {
        public int Id { get; set; }
        public string AssignedTo { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
    }
}
