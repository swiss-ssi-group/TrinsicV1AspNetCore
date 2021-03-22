
[![.NET](https://github.com/Franklin89/SSI-Sample/workflows/.NET/badge.svg)](https://github.com/Franklin89/SSI-Sample/actions?query=workflow%3A.NET) 


# Self Sovereign Identity (SSI)

# Testing and running the applications

## User secrets NationalDrivingLicense

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "--db-connection-string--"
  },
  "Trinsic": {
    "ApiKey":  "--your-api-key-organisation--",
    "TemplateDefinitionId": "--Template-credential-definition-id--"
  }
}
```

## User secrets BoInsurance

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
