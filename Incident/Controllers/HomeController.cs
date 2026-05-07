using Incident.Dtos;
using Incident.Models;
using Incident.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Incident.Controllers
{
    public class HomeController : Controller
    {
        private readonly IncidentService _incidentService;
        public HomeController(IncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var incidents = _incidentService.GetAll();
            return View(incidents);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateIncidentDto());
        }

        [HttpPost]
        public IActionResult Create(CreateIncidentDto obj)
        {
            _incidentService.CreateIncident(obj);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var incident = _incidentService.GetDetails(id);
            if (incident == null)
            {
                return NotFound();
            }
            return View(incident);
        }


        [HttpPost]
        public IActionResult UpdateStatus(UpdateStatusDto obj)
        {
            _incidentService.UpdateIncident(obj);
            return RedirectToAction(nameof(Details), new { id = obj.Id });
        }

        [HttpGet]
        public IActionResult Assign(int id)
        {
            var incident = _incidentService.GetDetails(id);
            if (incident == null)
            {
                return NotFound();
            }
            var assignDto = new AssignIncidentDto
            {
                Id = id,
                AssignedTo = incident.AssignedTo
            };
            return View(assignDto);
        }

        [HttpPost]
        public IActionResult Assign(AssignIncidentDto obj)
        {
            _incidentService.AssignIncident(obj);
            return RedirectToAction(nameof(Details), new { id = obj.Id });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
