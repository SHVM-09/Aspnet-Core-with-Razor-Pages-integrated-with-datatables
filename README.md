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
👉 _Remember to change `websiteName` at all places where it is uses to avoid errors_

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
### Step 10
#### Work & connect with a Local Database

- download [SQLite](https://www.sqlite.org/index.html)
  or
- Run in terminal `brew install sqlite` & check its version `sqlite3 --version` 💻 ![](https://img.shields.io/badge/For_MAC-purple)

- download [DB Browser for SQLite](https://sqlitebrowser.org/dl/)
  or
- Run in terminal `brew install --cask db-browser-for-sqlite` 💻 ![](https://img.shields.io/badge/For_MAC-purple)

### Step 11
#### Seed the Database

- Create a new class named SeedData in the Models folder with the following code:

```
using Microsoft.EntityFrameworkCore;
using websiteName.Data;
using System;

namespace websiteName.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new websiteNameContext(
                serviceProvider.GetRequiredService<DbContextOptions<websiteNameContext>>()))
            {
                if (context == null || context.Product == null)
                {
                    throw new ArgumentNullException("Null websiteNameContext");
                }

                // Look for any products.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Name = "Product 1",
                        Price = 10.99M,
                        ExpiryDate = DateTime.Parse("2023-10-01")
                    },

                    new Product
                    {
                        Name = "Product 2",
                        Price = 19.99M,
                        ExpiryDate = DateTime.Parse("2023-09-15")
                    },

                    new Product
                    {
                        Name = "Product 3",
                        Price = 5.49M,
                        ExpiryDate = DateTime.Parse("2023-11-05")
                    },

                    new Product
                    {
                        Name = "Product 4",
                        Price = 14.99M,
                        ExpiryDate = DateTime.Parse("2023-10-20")
                    },

                    new Product
                    {
                        Name = "Product 5",
                        Price = 67.99M,
                        ExpiryDate = DateTime.Parse("2023-10-20")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

```

### Step 12
#### Open the database accessing it from db browser (locate generated .db file) & update database with CLI

- Use `dotnet ef migrations add updateName` & `dotnet ef database update` to update data to local database.

<hr/>

##### Now Your Local .NET Project would be good to go & you can deploy it on Azure or any .NET Hosting Site
##### Still Learning about how to deploy a project with Database on Azure so will add it here after it is done! ⏲️






