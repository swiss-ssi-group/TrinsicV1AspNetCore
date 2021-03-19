using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trinsic.ServiceClients;
using Trinsic.ServiceClients.Models;

namespace NationalDrivingLicense
{
    public class TrinsicCredentialsProvider
    {
        private readonly ICredentialsServiceClient _credentialServiceClient;

        public TrinsicCredentialsProvider(ICredentialsServiceClient credentialServiceClient)
        {
            _credentialServiceClient = credentialServiceClient;
        }

        public async Task<CredentialContract> GetDriverLicenseCredential()
        {
            String connectionId = null; // Can be null | <connection identifier>
            Boolean automaticIssuance = false;
            IDictionary<string, string> credentialValues = new Dictionary<String, String>() {
                {"IssuedAt", "1"},
                {"Name", "2"},
                {"FirstName", "3"},
                {"DateOfBirth", "4"}
            };

            CredentialContract credential = await _credentialServiceClient
                .CreateCredentialAsync(new CredentialOfferParameters
            {
                // from the template
                DefinitionId = "FfsoKVr82kUQTMWqGVBhVQ:3:CL:195644:Default",
                ConnectionId = connectionId,
                AutomaticIssuance = automaticIssuance,
                CredentialValues = credentialValues
            });

            return credential;
        }
    }

     
}
