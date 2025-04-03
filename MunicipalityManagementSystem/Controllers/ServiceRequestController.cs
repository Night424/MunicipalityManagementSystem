using Microsoft.AspNetCore.Mvc;
using MunicipalityManagementSystem.Data;
using MunicipalityManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MunicipalityManagementSystem.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceRequest
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ServiceRequests.Include(s => s.Citizen);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ServiceRequest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequests
                .Include(s => s.Citizen)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            return View(serviceRequest);
        }

        // GET: ServiceRequest/Create
        public IActionResult Create()
        {
            ViewData["CitizenID"] = new SelectList(_context.Citizens, "CitizenID", "FullName");
            return View();
        }

        // POST: ServiceRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,CitizenID,ServiceType,Status")] ServiceRequest serviceRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CitizenID"] = new SelectList(_context.Citizens, "CitizenID", "FullName", serviceRequest.CitizenID);
            return View(serviceRequest);
        }

        // GET: ServiceRequest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }
            ViewData["CitizenID"] = new SelectList(_context.Citizens, "CitizenID", "FullName", serviceRequest.CitizenID);
            return View(serviceRequest);
        }

        // POST: ServiceRequest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,CitizenID,ServiceType,RequestDate,Status")] ServiceRequest serviceRequest)
        {
            if (id != serviceRequest.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceRequestExists(serviceRequest.RequestID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CitizenID"] = new SelectList(_context.Citizens, "CitizenID", "FullName", serviceRequest.CitizenID);
            return View(serviceRequest);
        }

        private bool ServiceRequestExists(int id)
        {
            return _context.ServiceRequests.Any(e => e.RequestID == id);
        }
    }
}