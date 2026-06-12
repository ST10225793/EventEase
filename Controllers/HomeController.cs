using EventEase.Data; // Ensure this points to your Data folder
using EventEase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EventEase.Controllers
{
    public class HomeController : Controller
    {
        // 1. Add the database context field
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        // 2. Update the Constructor to "Inject" the context
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Now _context exists!
        }

        public async Task<IActionResult> Index()
        {
            // 3. Pull the counts from the database
            ViewBag.VenueCount = await _context.Venues.CountAsync();
            ViewBag.EventCount = await _context.Events.CountAsync();
            ViewBag.BookingCount = await _context.Bookings.CountAsync();

            // Pull the latest 5 events to show on the dashboard
            var upcomingEvents = await _context.Events
                .Include(e => e.Venue) // This links the Venue name to the Event
                .OrderByDescending(e => e.EventDate)
                .Take(5)
                .ToListAsync();

            return View(upcomingEvents); // Send the list to the View
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