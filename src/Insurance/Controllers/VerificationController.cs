using Insurance.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trinsic.ServiceClients;

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
        public async Task<IActionResult> StartRequest()
        {
            // pay 1 credential
            var verificationRequest = await _diversLicenseVerificationService.CreateVerificationRequest();
            return Ok(new
            {
                verificationId = verificationRequest.verificationId,
                verificationUrl = $"https://chart.googleapis.com/chart?cht=qr&chl={verificationRequest.verificationUrl}&chs=300x300&chld=L|1"
            });
        }
    }
}