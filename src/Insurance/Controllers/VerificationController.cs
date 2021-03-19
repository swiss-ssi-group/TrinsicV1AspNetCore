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
        private readonly ICredentialsServiceClient _credentialsServiceClient;

        public VerificationController(ICredentialsServiceClient credentialsServiceClient)
        {
            _credentialsServiceClient = credentialsServiceClient;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CheckStatus(string verificationId)
        {
            //var verification = await _credentialsServiceClient.GetVerificationAsync(verificationId);
            return Ok(new { state = "accepted" });
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Url()
        {
            //private const string PolicyId = "be318d6b-16d5-43e0-31f1-08d8e54ca652";
            //var verificationContract = await _credentialsService.CreateVerificationFromPolicyAsync(PolicyId);
            //VerificationRequestUrl = verificationContract.VerificationRequestUrl;
            //VerificationId = verificationContract.VerificationId;

            await Task.Delay(2500);
            var verificationUrl = "https://google.com";
            return Ok(new
            {
                verificationId = Guid.NewGuid().ToString(),
                verificationUrl = $"https://chart.googleapis.com/chart?cht=qr&chl={verificationUrl}&chs=300x300&chld=L|1"
            });
        }
    }
}