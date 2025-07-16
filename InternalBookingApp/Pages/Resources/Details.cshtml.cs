using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InternalBookingApp.Data;
using InternalBookingApp.Models;

namespace InternalBookingApp.Pages.Resources
{
    public class DetailsModel : PageModel
    {
        private readonly InternalBookingAppContext _context;

        public DetailsModel(InternalBookingAppContext context)
        {
            _context = context;
        }

        public Resource? Resource { get; set; }

        public List<Booking> UpcomingBookings { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Load the resource
            Resource = await _context.Resources
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Resource == null)
            {
                return NotFound();
            }

            // Load upcoming bookings for this resource
            UpcomingBookings = await _context.Bookings
                .Where(b => b.ResourceId == id && b.EndTime > DateTime.Now)
                .OrderBy(b => b.StartTime)
                .ToListAsync();

            return Page();
        }
    }
}
