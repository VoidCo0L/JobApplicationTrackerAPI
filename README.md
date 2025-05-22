# 📋Job Application Tracker API

A simple ASP.NET Core Web API to track job applications.  
Supports two types of data storage repositories:
- Entity Framework Core with SQL Server
- JSON file persistence

---

## ✨Features

- CRUD operations for job applications
- Repository pattern with EF Core and JSON file implementations
- Swagger UI for API testing
- Asynchronous programming for better scalability

---

## 📦Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or any SQL Server instance)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or Visual Studio Code
- [SQL Server Management Studio (SSMS)](https://aka.ms/ssms) for database management

---

## 📚Required NuGet Packages

Make sure your project has the following NuGet packages installed:

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`
- `Swashbuckle.AspNetCore` (for Swagger)

You can install them via the **Package Manager Console** in Visual Studio:

```powershell
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Swashbuckle.AspNetCore
```
Or via the .NET CLI

- `dotnet add package Microsoft.EntityFrameworkCore`
- `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
- `dotnet add package Microsoft.EntityFrameworkCore.Tools`
- `dotnet add package Swashbuckle.AspNetCore`

## ⚙️Configuration
### Connection String

Update your appsettings.json with your SQL Server connection string.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS01;Database=JobApplicationDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
````
## 🗄️Database Setup
Run the following commands in your project root directory (where your .csproj is):
- `dotnet ef migrations add InitialCreate` creates the initial migration scripts based on your DbContext and models.
- `dotnet ef database update` applies the migration and creates the database with the required tables.

## ▶️Running the Application

Run your API project using Visual Studio or from the command line:

```bash
dotnet run
````
By default, Swagger UI will be available at:
`https://localhost:{port}/swagger`

Use Swagger to test the API endpoints like GET, POST, PUT, DELETE for job applications.

## 📌Dependency Injection Setup (Program.cs)
``` csharp
builder.Services.AddScoped<IJobApplicationRepository, JobApplicationEfRepository>();
builder.Services.AddScoped<IJobApplicationService, JobApplicationService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
````

## 📖Notes
- Use Entity Framework repository for production and SQL Server.
- Use JSON file repository for quick testing or if you want to persist data without a database.
- The repository interface is async to support scalability and efficient IO.

## 🛠️Troubleshooting

If you get errors running EF commands:

- Make sure your terminal's current directory is the folder containing the `.csproj` file.
- Ensure `Microsoft.EntityFrameworkCore.Tools` is installed.
- If your database doesn't update after POSTing new data, check if the repository calls `SaveChanges()` correctly.
