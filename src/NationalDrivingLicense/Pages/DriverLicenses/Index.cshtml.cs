using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NationalDrivingLicense.Data;

namespace NationalDrivingLicense.Pages.DriverLicenses
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<DriverLicence> DriverLicence { get;set; }

        public async Task OnGetAsync()
        {
            DriverLicence = await _context.DriverLicences.ToListAsync();
        }
    }
}
