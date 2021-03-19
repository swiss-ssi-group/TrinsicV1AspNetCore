﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NationalDrivingLicense
{
    public class AdminModel : PageModel
    {
        public IActionResult OnGet()
        {
            var claimTwoFactorEnabled = User.Claims.FirstOrDefault(t => t.Type == "amr");

            if (claimTwoFactorEnabled != null && "mfa".Equals(claimTwoFactorEnabled.Value))
            {
                // You logged in with MFA, do the admin stuff
            }
            else
            {
                // to test mfa check disabled
                // return Redirect("/Identity/Account/Manage/TwoFactorAuthentication");
            }

            return Page();
        }
    }
}