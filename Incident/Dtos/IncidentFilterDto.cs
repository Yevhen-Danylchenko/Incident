namespace Incident.Dtos
{
    public class IncidentFilterDto
    {
        public string? Status { get; set; }        
        public string? Priority { get; set; }      
        public string? Category { get; set; }      
        public string? AssignedTo { get; set; }   
        public DateTime? FromDate { get; set; }    
        public DateTime? ToDate { get; set; }
    }
}
