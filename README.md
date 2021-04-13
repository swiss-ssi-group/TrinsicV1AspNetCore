
[![.NET](https://github.com/Franklin89/SSI-Sample/workflows/.NET/badge.svg)](https://github.com/Franklin89/SSI-Sample/actions?query=workflow%3A.NET) 


# Self Sovereign Identity (SSI)

Self Sovereign Identity example for credential issuer and credential verification using ASP.NET Core

## Blogs


- [Getting started with Self Sovereign Identity SSI](https://damienbod.com/2021/03/29/getting-started-with-self-sovereign-identity-ssi/) by Damien
- [Creating Verifiable credentials in ASP.NET Core for decentralized identities using Trinsic](https://damienbod.com/2021/04/05/creating-verifiable-credentials-in-asp-net-core-for-decentralized-identities-using-trinsic/) by Damien
- [Verifying Verifiable Credentials in ASP.NET Core for Decentralized Identities using Trinsic](https://ml-software.ch/posts/verifiying-verifiable-credentials-using-trinsic) by Matteo

## Testing and running the applications

### User secrets NationalDrivingLicense

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "--db-connection-string--"
  },
  "Trinsic": {
    "ApiKey":  "--your-api-key-organisation--",
    "CredentialTemplateDefinitionId": "--Template-credential-definition-id--"
  }
}
```

### User secrets BoInsurance

```json
{
  "Trinsic": {
    "ApiKey": "--your-api-key-organisation-which-does-the-verification--",
    "NationalDrivingLicense": {
      "DID": "--your-DID-from-credential-issuer--"
    }
  }
}
```

## Links

https://studio.trinsic.id/

https://www.youtube.com/watch?v=mvF5gfMG9ps

https://github.com/trinsic-id/verifier-reference-app

https://docs.trinsic.id/docs/tutorial

https://sovrin.org/faq/what-is-self-sovereign-identity/

https://techcommunity.microsoft.com/t5/identity-standards-blog/ion-we-have-liftoff/ba-p/1441555

https://github.com/hyperledger/aries-framework-dotnet

https://github.com/Azure-Samples/active-directory-verifiable-credentials

https://www.microsoft.com/en/security/business/identity-access-management/decentralized-identity-blockchain

https://github.com/decentralized-identity/ion

https://bitbucket.org/openid/connect/src/master/openid-connect-self-issued-v2-1_0.md

https://www.lfph.io/wp-content/uploads/2021/02/Verifiable-Credentials-Flavors-Explained.pdf

https://techcommunity.microsoft.com/t5/identity-standards-blog/new-explorations-in-secret-recovery/ba-p/1441550

https://www.w3.org/TR/vc-data-model/
