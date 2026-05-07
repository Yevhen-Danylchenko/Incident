using System.ComponentModel.DataAnnotations;

namespace Incident.Dtos
{
    public class CreateIncidentDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress] 
        public string EmailAddress { get; set; } = string.Empty;
    }
}
