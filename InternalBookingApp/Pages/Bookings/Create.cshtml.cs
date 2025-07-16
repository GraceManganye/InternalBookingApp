using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternalBookingApp.Data;
using InternalBookingApp.Models;

namespace InternalBookingApp.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly InternalBookingAppContext _context;

        public CreateModel(InternalBookingAppContext context)
        {
            _context = context;
        }

        public SelectList ResourceList { get; set; } = default!;

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnGetAsync()
        {
            var resources = await _context.Resources
                .Where(r => r.IsAvailable)
                .ToListAsync();

            ResourceList = new SelectList(resources, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Rebind Resource dropdown for redisplay if validation fails
            var resources = await _context.Resources
                .Where(r => r.IsAvailable)
                .ToListAsync();
            ResourceList = new SelectList(resources, "Id", "Name");

            // Trigger model validation including IValidatableObject
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check for time conflicts for this resource
            bool isConflict = await _context.Bookings
                .AnyAsync(b =>
                    b.ResourceId == Booking.ResourceId &&
                    b.StartTime < Booking.EndTime &&
                    b.EndTime > Booking.StartTime);

            if (isConflict)
            {
                ModelState.AddModelError(string.Empty, "This resource is already booked during the requested time. Please choose another slot.");
                return Page();
            }

            // All checks passed — save to database
            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
