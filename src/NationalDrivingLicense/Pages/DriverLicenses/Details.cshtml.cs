using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NationalDrivingLicense.Data;

namespace NationalDrivingLicense.Pages.DriverLicenses
{
    public class DetailsModel : PageModel
    {
        private readonly NationalDrivingLicense.Data.ApplicationDbContext _context;

        public DetailsModel(NationalDrivingLicense.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public DriverLicence DriverLicence { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DriverLicence = await _context.DriverLicences.FirstOrDefaultAsync(m => m.Id == id);

            if (DriverLicence == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
