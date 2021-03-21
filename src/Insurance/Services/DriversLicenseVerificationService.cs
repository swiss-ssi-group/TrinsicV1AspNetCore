using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trinsic.ServiceClients;
using Trinsic.ServiceClients.Models;

namespace Insurance.Services
{
    public class DriversLicenseVerificationService
    {
        private readonly ICredentialsServiceClient _credentialsServiceClient;
        private readonly string _issuerDid;

        public DriversLicenseVerificationService(ICredentialsServiceClient credentialsServiceClient, IConfiguration configuration)
        {
            _credentialsServiceClient = credentialsServiceClient;
            _issuerDid = configuration["Trinsic:DMV:DID"];
        }

        public async Task<(string verificationId, string verificationUrl)> CreateVerificationRequest()
        {
            // Optional list of attribute policies
            IList<VerificationPolicyAttributeContract> attributePolicies = new List<VerificationPolicyAttributeContract>()
            {
                new VerificationPolicyAttributeContract()
                {
                    PolicyName = "Driver License Policy", // Name for policy
                    AttributeNames = new List<string>()
                    {
                        "Full Name"
                    }, // List of names of attributes to request
                    Restrictions = new List<VerificationPolicyRestriction>()
                    {
                        new VerificationPolicyRestriction
                        {
                            //SchemaId = "schemaId", // Optionally restrict by schema identifier
                            //SchemaIssuerDid = "schemaIssuerDid", // Optionally restrict by schema issuer identifier
                            //SchemaName = "schemaName", // Optionally restrict by schema name
                            //SchemaVersion = "schemaVersion", // Optionally restrict by schema version
                            IssuerDid = _issuerDid, // Optionally restrict by issuer identifier
                            //CredentialDefinitionId = "credentialDefinitionId", // Optionally restrict by credential definition identifier
                            //Value = new VerificationPolicyRestrictionAttribute
                            //{
                            //    AttributeName = "attributeName", // Name of attribute to restrict
                            //    AttributeValue = "attributeValue", // Value of attribute to restrict
                            //}
                        }
                    }
                }
            };

            // Optionally check if a revocable credential is valid at a given time
            var revocationRequirement = new VerificationPolicyRevocationRequirement()
            {
                ValidNow = true
                //ValidAt = new DateTime() // Check if the credential is valid at the time of verification creation
            };

            // Create the verification
            var verificationContract = await _credentialsServiceClient.CreateVerificationFromParametersAsync(
                new VerificationPolicyParameters
                {
                    Name = "Driver License Verification",
                    Version = "1.0", // Must follow Semantic Versioning scheme (https://semver.org),
                    Attributes = attributePolicies,
                    // RevocationRequirement = revocationRequirement
                });

            return (verificationId: verificationContract.VerificationId, verificationUrl: verificationContract.VerificationRequestUrl);
        }

        public async Task<string> GetVerificationState(string verificationId)
        {
            var verificationContract = await _credentialsServiceClient.GetVerificationAsync(verificationId);
            return verificationContract.State.ToLower();
        }
    }

    //internal class DriverLicense
    //{
    //    public Guid Id { get; set; }
    //    public Guid ApplicationUserId { get; set; }
    //    public DateTimeOffset IssuedAt { get; set; }
    //    public string Name { get; set; }
    //    public string FirstName { get; set; }
    //    public DateTimeOffset DateOfBirth { get; set; }
    //    public string Issuedby { get; set; }
    //    public bool Valid { get; set; }
    //    public string DriverLicenseCredentials { get; set; }
    //}
}
