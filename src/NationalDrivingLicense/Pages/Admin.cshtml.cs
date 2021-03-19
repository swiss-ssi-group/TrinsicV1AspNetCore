using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace NationalDrivingLicense
{
    public class AdminModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public AdminModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult OnGet()
        {
            var claimTwoFactorEnabled = User.Claims.FirstOrDefault(t => t.Type == "amr");

            if (claimTwoFactorEnabled != null && "mfa".Equals(claimTwoFactorEnabled.Value))
            {
                // You logged in with MFA, or MFA is disabled, do the admin stuff
            }
            else
            {
                var requireMfa = bool.Parse(_configuration["MfaRequiredForAdmin"]);
                if(requireMfa)
                {
                    return Redirect("/Identity/Account/Manage/TwoFactorAuthentication");
                }
            }

            return Page();
        }
    }
}