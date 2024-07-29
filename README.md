STEPS

Create api for public accessibility and the library for the code that will send the email

1. dotnet new webapi -n api

2. dotnet new classlib -n email

Add packages to your Library to send the Emails

1. dotnet add package Microsoft.Extensions.Configuration

2. dotnet add package Sendgrid

3. dotnet add package Microsoft.AspNetCore.Identity.UI.Services

In your api .csproj, add a reference to you class library:

`
<ItemGroup>
<ProjectReference Include="../email/email.csproj" />
</ItemGroup>
`

In Sendgrid, create your trial account and create an API Key. Then add your SendGrid API key to your appsettings.json file

  "SendGrid": {
    "SecretKey": ""
  }