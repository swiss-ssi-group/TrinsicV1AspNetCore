using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NationalDrivingLicense.Data;

namespace NationalDrivingLicense.Pages
{
    public class DriverLicenseCredentialsModel : PageModel
    {
        private readonly TrinsicCredentialsProvider _trinsicCredentialsProvider;
        private readonly DriverLicenseProvider _driverLicenseProvider;

        public string DriverLicenseMessage { get; set; } = "Loading credentials";
        public bool HasDriverLicense { get; set; } = false;
        public DriverLicense DriverLicense { get; set; }

        public string CredentialOfferUrl { get; set; }
        public DriverLicenseCredentialsModel(TrinsicCredentialsProvider trinsicCredentialsProvider,
           DriverLicenseProvider driverLicenseProvider)
        {
            _trinsicCredentialsProvider = trinsicCredentialsProvider;
            _driverLicenseProvider = driverLicenseProvider;
        }
        public async Task OnGetAsync()
        {
            DriverLicense = await _driverLicenseProvider.GetDriverLicense(HttpContext.User.Identity.Name);

            if (DriverLicense != null)
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
