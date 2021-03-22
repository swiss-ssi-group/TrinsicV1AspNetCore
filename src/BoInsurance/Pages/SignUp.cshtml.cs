using Insurance.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BoInsurance.Pages
{
    [ValidateAntiForgeryToken]
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public string VerificationUrl { get; set; }

        private readonly IDriversLicenseVerificationService _diversLicenseVerificationService;

        public SignUpModel(IDriversLicenseVerificationService diversLicenseVerificationService)
        {
            _diversLicenseVerificationService = diversLicenseVerificationService;
        }

        public class InputModel
        {
            public string VerificationId { get; set; }

            public string Name { get; set; }

            [Display(Name = "First name")]
            public string FirstName { get; set; }

            public string Address { get; set; }

            public string Zip { get; set; }

            public string City { get; set; }
        }

        public async Task OnGetAsync()
        {
            var verificationRequest = await _diversLicenseVerificationService.CreateVerificationRequest();
            VerificationUrl = verificationRequest.verificationUrl;
            Input.VerificationId = verificationRequest.verificationId;
        }

        public IActionResult OnPost([FromBody] InputModel input)
        {
            // Implement your custom logic here...
            // For example create an account for the user and allow him to login to the insurance applicaiton with his driver license.

            return RedirectToPage("/Index");
        }
    }
}
