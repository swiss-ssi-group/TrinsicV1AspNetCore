using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Insurance.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class WebhookController : Controller
    {
        private readonly ILogger<WebhookController> _logger;

        public WebhookController(ILogger<WebhookController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Webhook([FromBody]dynamic data)
        {
            var content = JsonConvert.SerializeObject(data, Formatting.Indented);
            _logger.LogInformation($"Received WebHook: {content}");
            return Ok();
        }
    }
}
