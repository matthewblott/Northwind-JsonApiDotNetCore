using System.Text;
using JsonApiDotNetCore.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Northwind.Web;
using Northwind.Web.Data;
using Northwind.Web.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
  .AddJsonFile("appsettings.json")
  .Build();

builder.WebHost.UseConfiguration(configuration);

var configSection = configuration.GetSection(nameof(JwtSettings));
var settings = new JwtSettings();

configSection.Bind(settings);

builder.Services.AddSingleton<IConfiguration>(_ => configuration);
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddOptions();
builder.Services.Configure<JwtSettings>(configSection);
builder.Services.AddMvc();

builder.Services.AddAuthentication(options =>
{
  options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
  options.RequireHttpsMetadata = false;
  options.SaveToken = true;
  options.TokenValidationParameters = new TokenValidationParameters
  {
    ValidIssuer = settings.Issuer,
    ValidAudience = settings.Audience,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key)),
    ValidateIssuerSigningKey = true,
    ValidateLifetime = true,
    ClockSkew = TimeSpan.Zero // the default for this setting is 5 minutes
  };
  options.Events = new JwtBearerEvents
  {
    OnAuthenticationFailed = context =>
    {
      if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
      {
        context.Response.Headers.Add("Token-Expired", true.ToString().ToLower());
      }
      return Task.CompletedTask;
    }
  };

});

// EntityFrameworkCore
builder.Services.AddDbContext<NorthwindDbContext>(options =>
{
  options.UseSqlite("Data Source=northwind.db;Pooling=False");
  options.EnableDetailedErrors();
  options.EnableSensitiveDataLogging();
  options.ConfigureWarnings(
      builder => builder.Ignore(CoreEventId.SensitiveDataLoggingEnabledWarning)
  );
});

builder.Services.AddControllers();

// JsonApiDotNetCore
builder.Services.AddJsonApi<NorthwindDbContext>(options =>
{
  options.Namespace = "api";
  options.UseRelativeLinks = true;
  options.IncludeTotalResourceCount = true;
  options.IncludeExceptionStackTraceInErrors = true;
  options.IncludeRequestBodyInErrors = true;
  options.SerializerOptions.WriteIndented = true; 
}, discovery => discovery.AddCurrentAssembly());

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseJsonApi();
app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();