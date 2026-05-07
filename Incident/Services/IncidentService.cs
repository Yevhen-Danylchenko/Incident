using Incident.Models;
using Incident.Dtos;

namespace Incident.Services
{
    public class IncidentService
    {
        private readonly List<Incident_1> _incidents = new List<Incident_1>();
        int genid = 1;
        public void CreateIncident(CreateIncidentDto obj)
        {
            var incident = new Incident_1
            {
                Id = genid,
                Title = obj.Title,
                Description = obj.Description,
                Category = obj.Category,
                Priority = "Low",
                Status = "New",
                CreatedAt = DateTime.Now,
                ReportedName = obj.Name,
                ReportedEmail = obj.EmailAddress,
                Comments = "",
                AssignedTo = "Test1"
            };
            _incidents.Add(incident);
        }

        public List<IncidentListDto> GetAll()
        {
            return _incidents.Select(_incidents => new IncidentListDto
            {
                Id = _incidents.Id,
                Priority = _incidents.Priority,
                Status = _incidents.Status,
                AssignedTo = _incidents.AssignedTo,
                CreatedAt = _incidents.CreatedAt
            }).ToList();
        }

        public IncidentDetailsDto GetDetails(int id)
        {
            var incident = _incidents.FirstOrDefault(i => i.Id == id);
            if (incident == null)
            {
                return null;
            }
            return new IncidentDetailsDto
            {
                Id = incident.Id,
                Title = incident.Title,
                Description = incident.Description,
                Category = incident.Category,
                Priority = incident.Priority,
                Status = incident.Status,
                Name = incident.ReportedName,
                EmailAddress = incident.ReportedEmail,
                AssignedTo = incident.AssignedTo,
                CreatedAt = incident.CreatedAt
            };
        }

        public void UpdateIncident(UpdateStatusDto obj)
        {
            var incident = _incidents.FirstOrDefault(i => i.Id == obj.Id);
            if (incident == null)
            {
                return;
            }
            incident.Status = obj.Status;
            incident.Comments = obj.Comment;
        }

        public void AssignIncident(AssignIncidentDto obj)
        {
            var incident = _incidents.FirstOrDefault(i => i.Id == obj.Id);
            if (incident == null)
            {
                return;
            }
            incident.AssignedTo = obj.AssignedTo;
            incident.Comments = obj.Comment;
            incident.Status = "Assigned"; 
        }

        public void CloseIncident(CloseIncidentDto obj)
        {
            var incident = _incidents.FirstOrDefault(i => i.Id == obj.Id);
            if (incident == null) return;

            incident.Status = "Closed";
            incident.Comments = obj.ClosingComment;
            incident.AssignedTo = incident.AssignedTo; 
            incident.Priority = incident.Priority;
            
        }

        public List<IncidentListDto> FilterIncidents(IncidentFilterDto filter)
        {
            var query = _incidents.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Status))
                query = query.Where(i => i.Status == filter.Status);

            if (!string.IsNullOrEmpty(filter.Priority))
                query = query.Where(i => i.Priority == filter.Priority);

            if (!string.IsNullOrEmpty(filter.Category))
                query = query.Where(i => i.Category == filter.Category);

            if (!string.IsNullOrEmpty(filter.AssignedTo))
                query = query.Where(i => i.AssignedTo == filter.AssignedTo);

            if (filter.FromDate.HasValue)
                query = query.Where(i => i.CreatedAt >= filter.FromDate.Value);

            if (filter.ToDate.HasValue)
                query = query.Where(i => i.CreatedAt <= filter.ToDate.Value);

            return query.Select(i => new IncidentListDto
            {
                Id = i.Id,
                Priority = i.Priority,
                Status = i.Status,
                AssignedTo = i.AssignedTo,
                CreatedAt = i.CreatedAt
            }).ToList();
        }
    }
}
