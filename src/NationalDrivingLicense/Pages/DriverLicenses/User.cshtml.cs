using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NationalDrivingLicense.Data;

namespace NationalDrivingLicense.Pages.DriverLicenses
{
    public class UserModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UserModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<DriverLicence> DriverLicence { get;set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DriverLicence = await _context.DriverLicences
                .AsQueryable()
                .Where(item => item.UserName == id)
                .ToListAsync();

            return Page();
        }
    }
}
