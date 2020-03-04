# ASP.NET Core 3.1 External API Request

A simple MVC app to show examples of how to consume an external API using ASP.NET Core 3.1

Features:
* Fetch data with a simple Http request
* Fetch data using authorization
* Display data on a Razor page
* Save data using EFCore

Steps:
* Create an ASP.NET Core MVC app using Visual Studio template
* Add EFCore and SQL Server to project via Nuget Package Manager
* Add Photo.cs to the Models folder
* Add the following code to Photo.cs
```
namespace ASPNETCoreExternalAPIRequest.Models
{
    public class Photo
    {
        public class RootObject
        {
            public int albumId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string url { get; set; }
            public string thumbnailUrl { get; set; }
        }

    }
}
```
* Add a Data folder with a POCO class named ApplicationDbContext.cs
* Add the following code to ApplicationDbContext.cs
```
using Microsoft.EntityFrameworkCore;
using ASPNETCoreExternalAPIRequest.Models;

namespace ASPNETCoreExternalAPIRequest.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Photo> Photos{ get; set; }
    }
}
```
* Add the following code to Startup.cs
```
using ASPNETCoreExternalAPIRequest.Data;
using Microsoft.EntityFrameworkCore;
...
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection")));
}
```
* Add the following code to appsettings.json
```
ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ASPNETCoreExternalAPIRequest-1;Trusted_Connection=True;MultipleActiveResultSets=true"
}
 ```
* Scaffold a MVC controller with CRUD pages
    * Add New Scaffolded Item -> MVC Controller with Views, using Entity Framework -> enter the model -> enter the database context -> Add

* Run the intial migration
    * From the Package Manager Console: 
        * Add-Migration InitialCreate
        * Update-Database

* In Shared/_Layout.cshtml, add a link to the photos index page
```
<li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-controller="Photos" asp-action="Index">Photos</a>
</li>
```