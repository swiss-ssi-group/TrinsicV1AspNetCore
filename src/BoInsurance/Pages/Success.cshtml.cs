using Insurance.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BoInsurance.Pages
{
    public class SuccessModel : PageModel
    {
        public string JsonResponse { get; set; }

        private readonly IDriversLicenseVerificationService _diversLicenseVerificationService;

        public SuccessModel(IDriversLicenseVerificationService diversLicenseVerificationService)
        {
            _diversLicenseVerificationService = diversLicenseVerificationService;
        }

        public async Task OnGetAsync(string verificationId)
        {
            JsonResponse = await _diversLicenseVerificationService.GetVerification(verificationId);
        }
    }
}
