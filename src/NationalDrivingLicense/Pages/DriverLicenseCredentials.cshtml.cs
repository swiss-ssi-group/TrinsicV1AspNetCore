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

        public string DriverLicenseMessage { get; set; } = "Loading credentials";
        public bool HasDriverLicense { get; set; } = false;
        public string CredentialOfferUrl { get; set; }
        public DriverLicenseCredentialsModel(TrinsicCredentialsProvider trinsicCredentialsProvider)
        {
            _trinsicCredentialsProvider = trinsicCredentialsProvider;
        }
        public async Task OnGetAsync()
        {
            if(await _trinsicCredentialsProvider
                .HasIdentityDriverLicense(HttpContext.User.Identity.Name))
            {
                var offerUrl = await _trinsicCredentialsProvider
                    .GetDriverLicenseCredential(HttpContext.User.Identity.Name);
                DriverLicenseMessage = "Add your driver license credentials to your wallet";
                CredentialOfferUrl = offerUrl;
                HasDriverLicense = true;
            }
            else
            {
                DriverLicenseMessage = "You have no valid driver license";
            }
        }
    }
}
