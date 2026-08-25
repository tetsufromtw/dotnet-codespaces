# Transaction Integration Practice Project

This repository is a small .NET solution prepared for a backend pair-programming
exercise. It runs entirely inside GitHub Codespaces and does not require paid
services, credentials, a database, or a real banking connection.

## Projects

- `SampleApp/BackEnd` — ASP.NET Core integration API on port `8080`
- `SampleApp/FrontEnd` — Blazor transaction console on port `8081`
- `Support/PartnerBankStub` — prebuilt local partner API on port `8082`

The partner contract is in [`docs/partner-bank-api.md`](docs/partner-bank-api.md).

## Run in Codespaces

Open **Run and Debug**, choose **Run All**, and start debugging. The configuration
builds and launches all three projects. It opens the backend Scalar page and the
Transaction Console automatically.

You can also run the projects from separate terminals:

```bash
dotnet Support/PartnerBankStub/PartnerBankStub.dll --urls http://localhost:8082
dotnet run --project SampleApp/BackEnd/BackEnd.csproj
dotnet run --project SampleApp/FrontEnd/FrontEnd.csproj
```

Build the complete solution with:

```bash
dotnet build SampleApp/SampleApp.sln
```

## Practice rule

The real interview does not allow AI tools. Copilot code completion is disabled
in this workspace so the exercise measures your own reasoning and coding. Use a
fresh attempt branch for each practice run and keep `interview-sim` unchanged.

Codespaces compute time still counts against the quota included with your GitHub
account. Stop the Codespace after each practice session to avoid unnecessary
usage; this project itself does not purchase or call any paid service.
