using System.Threading.Tasks;

namespace Insurance.Services
{
    public interface IDriversLicenseVerificationService
    {
        Task<(string verificationId, string verificationUrl)> CreateVerificationRequest();
        Task<string> GetVerificationState(string verificationId);
    }
}