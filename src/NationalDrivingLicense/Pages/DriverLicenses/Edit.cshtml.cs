using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NationalDrivingLicense.Data;

namespace NationalDrivingLicense.Pages.DriverLicenses
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UpdateDriverLicence DriverLicence { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverLicence = await _context.DriverLicences.FirstOrDefaultAsync(m => m.Id == id);

            DriverLicence = new UpdateDriverLicence
            {
                Id = driverLicence.Id,
                FirstName = driverLicence.FirstName,
                Name = driverLicence.Name,
                UserName = driverLicence.UserName,
                Valid = driverLicence.Valid
            };

            if (DriverLicence == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var toSave = await _context.DriverLicences.FirstOrDefaultAsync(m => m.Id == DriverLicence.Id);
            toSave.Valid = DriverLicence.Valid;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverLicenceExists(DriverLicence.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./User", new { id = toSave.UserName });
        }

        private bool DriverLicenceExists(Guid id)
        {
            return _context.DriverLicences.Any(e => e.Id == id);
        }
    }
}
