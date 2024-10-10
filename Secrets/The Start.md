# C# Secret Management

![pic2](https://github.com/MinenhleNkosi/Advanced-C-Sharp/blob/main/1.%20Secrets/Images/2.png)

In this article we will talk about C# secret management and how to use them.

## Sensitive data leakage
Sensitive information that shouldn’t be stored in source code. Different sorts of credentials, API keys, SSH keys, encryption keys, database passwords, are examples of sensitive information that should be avoided from being leaked into source code.

## Why not hard-coding sensitive data?
Storing sensitive data such as passwords in source code makes the application vulnerable to security attacks. One of the reasons is that most of the time not all developers need to know all credentials. Even if all developers are allowed to access all credentials, development environments, deployment pipelines, and servers are not designed to keep hard coded secrets safe. Another issue with hard-coding passwords is that the administrator would be unable to change the secrets at runtime. He may be forced to disable the product entirely in case of secret theft.

## How to Store Sensitive Data for Development?
Sensitive data should be stored in a different location from the project tree. Source code is best not to depend on the location or format of the data because they may change. Secret Manager is a tool that stores sensitive data during the development of [ASP.NET](http://asp.net/) projects, and hides implementation details such as location and format of the data being stored.



## Step by Step Guide to C# Secret Management

1. Let’s create an empty web project first:
```cs
    dotnet new web
```

2. Now let’s open the project using an IDE:
![pic4](https://github.com/MinenhleNkosi/Advanced-C-Sharp/blob/main/1.%20Secrets/Images/4.webp)

3. And to enable secret storage let’s run the init command in the project’s directory:
```cs
    dotnet user-secrets init
```

4. Now let’s set a new secret:
```cs
    dotnet user-secrets set "SecretObjectName:Key" "Value"
```

5. To check if the secret is stored successfully I can `list` all secrets:
```cs
    dotnet user-secrets list
```

6. The list currently contains a single secret:
```
    SecretObjectName:Key = Value
```


## Mapping Secrets to Dotnet Classes

The secret can also be directly mapped to the properties of a simple dotnet class.
Let’s create a new class named “Settings”, and add a property with the same name as the secret’s key.
```cs
    public class Settings
    {
        public string? Key { get; set; }
    }
```

Let’s open the `Program.cs` file again, and load the configuration section containing the secret into the Settings file. And reveal the secret by the web API.
```cs
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();
    
    //Read the secret we stored using Secret Manager
    var settings = builder.Configuration.GetSection("SecretObjectName").Get&lt;Settings&gt;();
    //Reveal the secret on web 😉
    app.MapGet("/poco", () =&gt; settings.Key);
    
    app.Run();
```


## Accessing Secrets From a Controller.
Let’s add a controller named `SecretController` with an action which returns an empty string.
```cs
    [ApiController]
    [Route("controller")]
    public class SecretController : ControllerBase
    {
        [HttpGet]
        public string Get()
        =&gt; "";
    }
```

## The `Program.cs` file should look like this:
```cs
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();
    var app = builder.Build();
    app.MapControllers();
    app.Run();
```

To returns the secret let’s inject the `Settings` class we built in previous section to the controller’s constructor and instead of returning the empty string return the secret’s value.
```cs
    [ApiController]
    [Route("controller")]
    public class SecretController : ControllerBase
    {
        private readonly Settings settings;
    
        public SecretController(Settings settings)
        =&gt; this.settings = settings;
    
        [HttpGet]
        public string Get()
        =&gt; settings.Key ?? "Not found";
    }
```

We should also configure the web application from `Program.cs` file. The `Settings` class should be added to the service collection.
```cs
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();
    
    //Read the secret we stored using Secret Manager
    var settingToBeInjected = builder.Configuration.GetSection("SecretObjectName").Get&lt;Settings&gt;();
    //Add it to the service collection.
    builder.Services.AddSingleton(settingToBeInjected);
    
    var app = builder.Build();
    app.MapControllers();
    app.Run();
```

Let’s run the application and open the `/controller` route in the browser to see the secret.



## Storing Connection String Passwords
Rather than storing passwords to database connection strings in plain text in configuration files, I would omit the password from connection strings, and store the password using Secret Manager. To add the password to a connection string at run time I would use the Configuration API to load both the connection string and its password individually. I can then use the `ConnectionStringBuilder` class to add the password to the connection string at run time.

Let’s see it in action. Let’s open the `appsettings.json` file, and add a connection string to it.
```cs
    {
        "ConnectionStrings": {
            "MyInsecureDb": "Server=(localdb)\\mssqllocaldb;Database=MyDb;User Id=Mohsen;Password=dbPassValue;MultipleActiveResultSets=true",
        }
    }
```

And remove the password from the connection string:
```cs
    {
        "ConnectionStrings": {
            "MySecureDb": "Server=(localdb)\\mssqllocaldb;Database=MyDb;User Id=Mohsen;MultipleActiveResultSets=true"
        }
    }
```

And add it to the user’s secrets:
```cs
    dotnet user-secrets set "DbPass" "dbPassValue"
```

To read the connection string let’s open the `Program.cs` file, and read the connection string, the password, add the password to the connection string, and finally reveal it on the web.
```cs
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();
    
    //Load the connection string:
    var conStrBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("MySecureDb"));
    
    //Load the password:
    var dbPassword = builder.Configuration["SecretObjectName:Key"];
    
    //Add the password to connection string to make it usable
    conStrBuilder.Password = builder.Configuration["DbPass"];
    
    //Reveal the complete connection string via web API
    app.MapGet("/constr", () =&gt; conStrBuilder.ConnectionString);
    
    app.Run();
```


## Remove Secrets
To remove a secret go to project’s folder and run this command:
```cs
    dotnet user-secrets remove SECRET_KEY
```

## Clearing All Secrets
To clear all secrets go to the project’s folder and run this command:
```cs
    dotnet user-secrets clear
```

## Where Are The Secrets Stored Physically?
Whenever I call `dotnet user-secrets set ...` the secret is stored in a `secrets.json` file by default. `secrets.json` file is stored in the local machine’s user profile folder:
```
    Windows 	%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json
```

To open the `secrets.json` file replace <user_secrets_id> with the GUID. This id connects the `secrets.json` file to the app. Both Secret Manager and Configuration API use this GUID to find the `secrets.json` file which belongs to your application.

-------------------------------------

# Use .NET Secrets in a Console Application
.NET Core made it easy to configure your application. Currently, I am working on a **.NET 6** console application and this showed me that especially **ASP.NET MVC** makes it easy to set up **middleware** such as **dependency injection**. When using a console application, it is not hard but it requires a bit more work than the web application.

## Create a new .NET 6 console application
Create a new **.NET 6** console application using your favorite IDE or the command line. First, add install the following two NuGet packages
```cs
    Install-Package Microsoft.Extensions.Configuration
    Install-Package Microsoft.Extensions.Hosting
```

Next, create a new class, that will read the appsettings file and also the **NETCORE_ENVIRONMENT** environment variable.
```cs
    using Microsoft.Extensions.Configuration;

    namespace ReadSecretsConsole;

    public class SecretAppsettingReader
    {
        public T ReadSection<T>(string sectionName)
        {
            var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables();
            var configurationRoot = builder.Build();

            return configurationRoot.GetSection(sectionName).Get<T>();
        }
    }
```
The `NETCORE_ENVIRONMENT` variable is the default variable to configure your environment in `.NET`. This variable contains values such as **Development** or **Production** and can be used to read a second appsettings file for the specific environment. For example, in production, you have a file called `appsettings.Production.json` which overrides some values from the `appsettings.json` file.

Next, add a new file, called `appsettings.json`, and add the following code there:
```cs
    {
        "MySecretValues": {
            "Username": "Abc",
            "Password": "Xyz"
        }
    }
```
This file contains a username and password. Values that should never be checked into source control!

Lastly, add the following code to your Program.cs file:
```cs
    using ReadSecretsConsole;

    var secretAppsettingReader = new SecretAppsettingReader();
    var secretValues = secretAppsettingReader.ReadSection<SecretValues>("MySecretValues");

    Console.WriteLine($"The user name is: {secretValues.Username}, and the password is: {secretValues.Password}");

    Console.ReadKey();
```
This code creates a new instance of SecretAppsettingReader and then reads the values from the `appsettings.json` file. Start the applications and you should see the values printed to the console.

```output
    The user name is: Abc, and the password is: Xyz
```

## Add Secrets to your Application

The application works and reads the username and password from the appsettings file. If a developer adds his password during the development, it is possible that this password gets forgotten and ends up in the source control. To mitigate accidentally adding passwords to the source control, .NET introduced secrets.

### To add a secret:
1. Right-click on your project and then select “Manage User Secrets” in Visual Studio. This should create a secrets.json file and add the Microsoft.Extensions.Configuration.UserSecrets NuGet package. Sometimes Visual Studio 2022 doesn’t install the package, so you have to install it by hand with the following command:
```cs
    Install-Package Microsoft.Extensions.Configuration.UserSecrets
```

2. You can use the secrets.json file the same way as you would use the appsettings.json file. For example, add the “MySecretValues” section and a new value for the “Password”:
```cs
    {
        "MySecretValues": {
            "Password": "SecretPassword"
        }
    }
```

3. There is one more thing you have to do before you can use the secrets.json file. You have to read the file using AddUserSecrets in the SecretAppsettingReader file:
```cs
    using Microsoft.Extensions.Configuration;

    namespace ReadSecretsConsole;

    public class SecretAppsettingReader
    {
        public T ReadSection<T>(string sectionName)
        {
            var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddUserSecrets<Program>()
                .AddEnvironmentVariables();
            var configurationRoot = builder.Build();

            return configurationRoot.GetSection(sectionName).Get<T>();
        }
    }
```

4. The AddUserSecrets method takes a type that indicates in what assembly the secret resides. Here I used Program, but you could use any other class inside the assembly.

5. Start the application and you should see that the password is the same value as in the secrets.json file.
```output
    The user name is: Abc, and the password is: Xyz
```
 The password was read from the secret

When you check in your code into Git, you will see that there is no secrets.json file to be checked in. Therefore, it is impossible to check in your secrets like passwords.
