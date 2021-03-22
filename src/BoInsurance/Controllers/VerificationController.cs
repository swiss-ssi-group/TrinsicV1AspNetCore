using Insurance.Services;
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
            return Ok(new { state = verificationState });
        }
    }
}