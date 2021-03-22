﻿using Insurance.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class VerificationController : Controller
    {
        private readonly IDriversLicenseVerificationService _diversLicenseVerificationService;

        public VerificationController(IDriversLicenseVerificationService diversLicenseVerificationService)
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

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateVerification()
        {
            var verificationRequest = await _diversLicenseVerificationService.CreateVerificationRequest();
            return Ok(new
            {
                verificationId = verificationRequest.verificationId,
                verificationUrl = verificationRequest.verificationUrl
            });
        }
    }
}