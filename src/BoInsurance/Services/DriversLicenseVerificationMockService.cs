using System;
using System.Threading.Tasks;

namespace Insurance.Services
{
    public class DriversLicenseVerificationMockService : IDriversLicenseVerificationService
    {
        public Task<(string verificationId, string verificationUrl)> CreateVerificationRequest()
        {
            return Task.FromResult((verificationId: Guid.NewGuid().ToString(), verificationUrl: "https://github.com"));
        }

        public Task<string> GetVerificationState(string verificationId)
        {
            return Task.FromResult("accepted");
        }
    }
}
