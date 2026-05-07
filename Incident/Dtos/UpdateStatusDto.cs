using System.ComponentModel.DataAnnotations;

namespace Incident.Dtos
{
    public class UpdateStatusDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        public string Comment { get; set; }
    }
}
