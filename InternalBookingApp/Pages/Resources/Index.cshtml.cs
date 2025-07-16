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
    public class IndexModel : PageModel
    {
        private readonly InternalBookingApp.Data.InternalBookingAppContext _context;

        public IndexModel(InternalBookingApp.Data.InternalBookingAppContext context)
        {
            _context = context;
        }

        public IList<Resource> Resource { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Resource = await _context.Resources.ToListAsync();
        }
    }
}
