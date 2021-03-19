using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NationalDrivingLicense.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trinsic.ServiceClients;
using Trinsic.ServiceClients.Models;

namespace NationalDrivingLicense
{
    public class TrinsicCredentialsProvider
    {
        private readonly ICredentialsServiceClient _credentialServiceClient;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;

        private DriverLicence _driverLicence { get; set; }

        public TrinsicCredentialsProvider(ICredentialsServiceClient credentialServiceClient,
            ApplicationDbContext applicationDbContext,
            IConfiguration configuration)
        {
            _credentialServiceClient = credentialServiceClient;
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
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

        public async Task<string> GetDriverLicenseCredential(string username)
        {
            if (!await HasIdentityDriverLicense(username))
            {
                throw new ArgumentException("user has no valid driver license");
            }

            if (!string.IsNullOrEmpty(_driverLicence.DriverLicenceCredentials))
            {
                return _driverLicence.DriverLicenceCredentials;
            }

            string connectionId = null; // Can be null | <connection identifier>
            bool automaticIssuance = false;
            IDictionary<string, string> credentialValues = new Dictionary<String, String>() {
                {"Issued At", _driverLicence.IssuedAt.ToString()},
                {"Name", _driverLicence.Name},
                {"First Name", _driverLicence.FirstName},
                {"Date of Birth", _driverLicence.DateOfBirth.Date.ToString()},
                {"License Type", _driverLicence.LicenseType}
            };

            CredentialContract credential = await _credentialServiceClient
                .CreateCredentialAsync(new CredentialOfferParameters
                {
                    DefinitionId = _configuration["Trinsic:TemplateDefinitionId"],
                    ConnectionId = connectionId,
                    AutomaticIssuance = automaticIssuance,
                    CredentialValues = credentialValues
                });

            _driverLicence.DriverLicenceCredentials = credential.OfferUrl;
            _applicationDbContext.DriverLicences.Update(_driverLicence);
            await _applicationDbContext.SaveChangesAsync();

            return credential.OfferUrl;
        }
    }


}
