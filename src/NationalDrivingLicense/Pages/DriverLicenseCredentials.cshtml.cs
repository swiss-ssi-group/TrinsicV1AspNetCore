using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NationalDrivingLicense.Pages
{
    public class DriverLicenseCredentialsModel : PageModel
    {
        private readonly TrinsicCredentialsProvider _trinsicCredentialsProvider;

        public DriverLicenseCredentialsModel(TrinsicCredentialsProvider trinsicCredentialsProvider)
        {
            _trinsicCredentialsProvider = trinsicCredentialsProvider;
        }
        public void OnGet()
        {
        }
    }
}
