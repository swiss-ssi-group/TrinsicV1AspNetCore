using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NationalDrivingLicense.Data;

namespace NationalDrivingLicense.Pages.DriverLicenses
{
    public class CreateModel : PageModel
    {
        private readonly NationalDrivingLicense.Data.ApplicationDbContext _context;

        public CreateModel(NationalDrivingLicense.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DriverLicence DriverLicence { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DriverLicence.Issuedby = HttpContext.User.Identity.Name;
            DriverLicence.IssuedAt = DateTimeOffset.UtcNow;

            _context.DriverLicences.Add(DriverLicence);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
