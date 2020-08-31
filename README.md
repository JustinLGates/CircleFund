# .NET-WebApi-with-auth-template

This template is set up with JwtBearer authentication, and a gearhost sql database.

## Setup

#### Step 1
use the template to create your project

#### Step 2.
cd into your root directory. Using your terminal/CLI add the following packages
dotnet add package dapper
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package MySqlConnector

#### Step 3
If you do not have Gearhost and Auth0 account go set them up now.

Add app settings JSON files to the root directory.

**appsettings.json**

**appsettings.Development.json**

These files are used to set the connection and authentication for your application.
The example below is what needs to go inside just add in your own credentials.

Example :
```JSON
{

"DB": {
"gearhost": "server=serverName;port=3306;database=DBName;user id=username;password=yourpassword;"
},
"Auth0": {
"Domain": "yourAuth0Domain",
"Audience": "yourAuth0Audience"
}

}
```
### All set 
One thing i am looking to improve is naming the csproj files. Please let me know if you know if your interested in helping. 
