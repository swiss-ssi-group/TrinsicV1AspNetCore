using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NationalDrivingLicense.Data;

namespace NationalDrivingLicense.Pages.DriverLicenses
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public string UserName { get; set; }
        [BindProperty]
        public DriverLicense DriverLicence { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserName = id;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DriverLicence.Issuedby = HttpContext.User.Identity.Name;
            DriverLicence.IssuedAt = DateTimeOffset.UtcNow;

            _context.DriverLicenses.Add(DriverLicence);
            await _context.SaveChangesAsync();

            return RedirectToPage("./User", new { id = DriverLicence.UserName });
        }
    }
}
