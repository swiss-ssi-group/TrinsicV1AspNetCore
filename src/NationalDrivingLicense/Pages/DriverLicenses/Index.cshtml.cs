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
    public class IndexModel : PageModel
    {
        private readonly NationalDrivingLicense.Data.ApplicationDbContext _context;

        public IndexModel(NationalDrivingLicense.Data.ApplicationDbContext context)
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
