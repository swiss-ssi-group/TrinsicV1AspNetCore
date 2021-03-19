using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Trinsic.ServiceClients;

namespace Insurance.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly ICredentialsServiceClient _credentialsService;
        private readonly IConfiguration _configuration;

        // This is the Verification Id inside of the Trinsic Studio
        private const string PolicyId = "be318d6b-16d5-43e0-31f1-08d8e54ca652"; 

        public string VerificationRequestUrl { get; set; }
        public string VerificationId { get; set; }

        public SignUpModel(ICredentialsServiceClient credentialsService, IConfiguration configuration)
        {
            _credentialsService = credentialsService;
            _configuration = configuration;
        }

        public async Task OnGet()
        {
            //var verificationContract = await _credentialsService.CreateVerificationFromPolicyAsync(PolicyId);
            //VerificationRequestUrl = verificationContract.VerificationRequestUrl;
            //VerificationId = verificationContract.VerificationId;
        }
    }
}
