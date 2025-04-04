using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MunicipalityManagementSystem.Models;
using MunicipalityManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using MunicipalityManagementSystem.ViewModels;

namespace MunicipalityManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Get counts for dashboard statistics
            var model = new DashboardViewModel
            {
                CitizenCount = _context.Citizens.Count(),
                ServiceRequestCount = _context.ServiceRequests.Count(),
                StaffCount = _context.Staff.Count(),
                ReportCount = _context.Reports.Count(),
                RecentServiceRequests = _context.ServiceRequests
                    .Include(sr => sr.Citizen)
                    .OrderByDescending(sr => sr.RequestDate)
                    .Take(5)
                    .ToList()
            };
            
            return View(model);
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
