STEPS

dotnet new webapi -n api
dotnet new classlib -n email

dotnet add package Microsoft.Extensions.Configuration
dotnet add package Sendgrid
dotnet add package Microsoft.AspNetCore.Identity.UI.Services

in your api .csproj:

<ItemGroup>
    <ProjectReference Include="../email/email.csproj" />
</ItemGroup>

add your SendGrid API key to your appsettings.json file

  "SendGrid": {
    "SecretKey": ""
  }