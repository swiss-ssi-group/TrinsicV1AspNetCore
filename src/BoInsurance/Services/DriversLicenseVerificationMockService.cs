using System;
using System.Threading.Tasks;

namespace Insurance.Services
{
    public class DriversLicenseVerificationMockService : IDriversLicenseVerificationService
    {
        public async Task<(string verificationId, string verificationUrl)> CreateVerificationRequest()
        {
            await Task.Delay(1500);
            return (verificationId: Guid.NewGuid().ToString(), verificationUrl: "https://github.com");
        }

        public Task<string> GetVerificationState(string verificationId)
        {
            return Task.FromResult("accepted");
        }
    }
}
