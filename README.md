# Aspnet-Core-with-Razor-Pages-integrated-with-datatables
Aspnet Core Razor Pages integrated with datatables + CRUD + SQLite


### Required Technologies

![](https://img.shields.io/badge/NET_7-red)
![](https://img.shields.io/badge/Bootstrap_5-green)
![](https://img.shields.io/badge/Vs_Code-blue)
![](https://img.shields.io/badge/SQLite-yellow)
![](https://img.shields.io/badge/DB_Browser-SQLite-pink)

### Step 1
#### Create aspnet core app website base/structure

```
dotnet new webapp -o websiteName
code -r websiteName
```

### Step 2
#### Trust the HTTPS development certificate

```
dotnet dev-certs https --trust
```

### Step 3
#### Add a Data Model

- Add a folder named Models
- Add a class to the Models folder named ModelName(As per your choice) Here I have kept it Product
- Class Example:

```
using System.ComponentModel.DataAnnotations;

namespace websiteName.Models;

public class ModelName
{
    public int Id { get; set; } // For ID Data
    public string? Title { get; set; } // For Title Data
    public decimal Price { get; set; } // For Price Data
    [DataType(DataType.Date)]
    public DateTime ExpiryDate { get; set; } { get; set; } // For Expiry Date Data
}
```

### Step 4
#### Add NuGet Packages & EF Tools

```
dotnet tool uninstall --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-aspnet-codegenerator // Scaffolding Tool
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef // Tools for EF Core
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite // EF SQLite Provider
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design 
dotnet add package Microsoft.EntityFrameworkCore.SqlServer // Package for Scaffolding
dotnet add package Microsoft.EntityFrameworkCore.Tools // Package for Scaffolding
```

### Step 5
#### Scaffold the Model

```
dotnet aspnet-codegenerator razorpage -m ModelName(Product) -dc websiteName.Data.websiteNameContext -udl -outDir Pages/Products --referenceScriptLibraries --databaseProvider sqlite
```
<br/>
```
dotnet aspnet-codegenerator razorpage -h // to get help on generator command
```

### Step 6
#### Create the initial database schema using EF's migration feature

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Step 7
#### Test App (Preliminary test)

```
dotnet build // build the app
dotnet watch // run the app with auto reload
dotnet run // run the app without auto reload
```

### Step 8
#### Check Generated CRUD pages (Create, Delete, Details, and Edit)

### Step 9
#### Update the layout to check the crud table generated

- Change the `<title>` element in the `Pages/Shared/_Layout.cshtml` file to display `ModelName(Product)` rather than `websiteName`.

```
<title>@ViewData["Title"] - ModelName</title>
```
- Find the following anchor element in the `Pages/Shared/_Layout.cshtml` file

```
<a class="navbar-brand" asp-area="" asp-page="Products/Index">Products</a>
```






