using JsonApiDotNetCore.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Northwind.Web.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NorthwindDbContext>(options =>
{
  options.UseSqlite("Data Source=northwind.db;Pooling=False");
  
  options.EnableDetailedErrors();
  options.EnableSensitiveDataLogging();
  options.ConfigureWarnings(builder => builder.Ignore(CoreEventId.SensitiveDataLoggingEnabledWarning));
});

builder.Services.AddJsonApi<NorthwindDbContext>(options =>
{
  options.Namespace = "api";
  options.UseRelativeLinks = true;
  options.IncludeTotalResourceCount = true;

  options.IncludeExceptionStackTraceInErrors = true;
  options.IncludeRequestBodyInErrors = true;
  options.SerializerOptions.WriteIndented = true;
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseJsonApi();
app.MapControllers();
//app.MapDefaultControllerRoute();

app.Run();