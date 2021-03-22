using Insurance.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class VerificationController : Controller
    {
        private readonly DriversLicenseVerificationService _diversLicenseVerificationService;

        public VerificationController(DriversLicenseVerificationService diversLicenseVerificationService)
        {
            _diversLicenseVerificationService = diversLicenseVerificationService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CheckStatus(string verificationId)
        {
            var verificationState = await _diversLicenseVerificationService.GetVerificationState(verificationId);

            // IDEA: After we have verified the user we could create an account for him

            return Ok(new { state = verificationState });
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CreateVerification()
        {
            // test UI without verify credential call
            //return Ok(new
            //{
            //    verificationId = "test",
            //    verificationUrl = "www.damienbod.com"
            //});

            // pay 1 credential
            var verificationRequest = await _diversLicenseVerificationService.CreateVerificationRequest();
            return Ok(new
            {
                verificationId = verificationRequest.verificationId,
                verificationUrl = verificationRequest.verificationUrl
            });
        }
    }
}