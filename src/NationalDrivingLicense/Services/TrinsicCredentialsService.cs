using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trinsic.ServiceClients;
using Trinsic.ServiceClients.Models;

namespace NationalDrivingLicense
{
    public class TrinsicCredentialsService
    {
        private readonly ICredentialsServiceClient _credentialServiceClient;
        private readonly IConfiguration _configuration;
        private readonly DriverLicenseService _driverLicenseService;

        public TrinsicCredentialsService(ICredentialsServiceClient credentialServiceClient,
            IConfiguration configuration,
            DriverLicenseService driverLicenseService)
        {
            _credentialServiceClient = credentialServiceClient;
            _configuration = configuration;
            _driverLicenseService = driverLicenseService;
        }

        public async Task<string> GetDriverLicenseCredential(string username)
        {
            if (!await _driverLicenseService.HasIdentityDriverLicense(username))
            {
                throw new ArgumentException("user has no valid driver license");
            }

            var driverLicense = await _driverLicenseService.GetDriverLicense(username);

            if (!string.IsNullOrEmpty(driverLicense.DriverLicenseCredentials))
            {
                return driverLicense.DriverLicenseCredentials;
            }

            string connectionId = null; // Can be null | <connection identifier>
            bool automaticIssuance = false;
            IDictionary<string, string> credentialValues = new Dictionary<String, String>() {
                {"Issued At", driverLicense.IssuedAt.ToString()},
                {"Name", driverLicense.Name},
                {"First Name", driverLicense.FirstName},
                {"Date of Birth", driverLicense.DateOfBirth.Date.ToString()},
                {"License Type", driverLicense.LicenseType}
            };

            CredentialContract credential = await _credentialServiceClient
                .CreateCredentialAsync(new CredentialOfferParameters
                {
                    DefinitionId = _configuration["Trinsic:TemplateDefinitionId"],
                    ConnectionId = connectionId,
                    AutomaticIssuance = automaticIssuance,
                    CredentialValues = credentialValues
                });

            driverLicense.DriverLicenseCredentials = credential.OfferUrl;
            await _driverLicenseService.UpdateDriverLicense(driverLicense);

            return credential.OfferUrl;
        }
    }
}
