using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NationalDrivingLicense.Data;
using System;
using System.Threading.Tasks;

namespace NationalDrivingLicense
{
    public class DriverLicenseProvider
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DriverLicenseProvider(ApplicationDbContext applicationDbContext,
            IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> HasIdentityDriverLicense(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var driverLicence = await _applicationDbContext.DriverLicences.FirstOrDefaultAsync(
                    dl => dl.UserName == username && dl.Valid == true
                );

                if (driverLicence != null)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<DriverLicence> GetDriverLicense(string username)
        {
            var driverLicence = await _applicationDbContext.DriverLicences.FirstOrDefaultAsync(
                    dl => dl.UserName == username && dl.Valid == true
                );

            return driverLicence;
        }

        public async Task UpdateDriverLicense(DriverLicence driverLicense)
        {
            _applicationDbContext.DriverLicences.Update(driverLicense);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
