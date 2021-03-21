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

        private DriverLicence _driverLicence { get; set; }

        public DriverLicenseProvider(ApplicationDbContext applicationDbContext,
            IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> HasIdentityDriverLicense(string username)
        {
            if (_driverLicence != null)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(username))
            {
                var driverLicence = await _applicationDbContext.DriverLicences.FirstOrDefaultAsync(
                    dl => dl.UserName == username && dl.Valid == true
                );

                if (driverLicence != null)
                {
                    // cache this in the service (scoped service)
                    _driverLicence = driverLicence;
                    return true;
                }
            }

            return false;
        }

        public async Task<DriverLicence> GetDriverLicense(string username)
        {
            if (!await HasIdentityDriverLicense(username))
            {
                throw new ArgumentException("user has no valid driver license");
            }

            return _driverLicence;
        }

        public async Task UpdateDriverLicense(DriverLicence driverLicense)
        {
            _applicationDbContext.DriverLicences.Update(driverLicense);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
