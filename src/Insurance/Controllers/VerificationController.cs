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
            return Ok(new { state = "accepted" });
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> StartRequest()
        {
            var verificationRequest = await _diversLicenseVerificationService.CreateVerificationRequest();
            return Ok(new
            {
                verificationId = verificationRequest.verificationId,
                verificationUrl = $"https://chart.googleapis.com/chart?cht=qr&chl={verificationRequest.verificationUrl}&chs=300x300&chld=L|1"
            });
        }
    }
}