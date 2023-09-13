using Ardalis.ListStartupServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using TEKO.Testing.Core;
using TEKO.Testing.Infrastructure;
using TEKO.Testing.Infrastructure.Data;
using TEKO.Testing.Web;
using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpoints.ApiExplorer;
using Serilog;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(o =>
{
  o.DetailedErrors = true;
});

builder.Services.AddHttpClient();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

string? connectionString = builder.Configuration.GetConnectionString("SqliteConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
          options.UseSqlite(connectionString));

builder.Services.AddMudServices();

builder.Services.AddFastEndpoints();

builder.Services.SwaggerDocument(o =>
{
  o.ShortSchemaNames = true;
});


builder.Services.Configure<ServiceConfig>(config =>
{
  config.Services = new List<ServiceDescriptor>(builder.Services);
  config.Path = "/listservices";
});


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(new AutofacInfrastructureModule(builder.Environment.IsDevelopment()));
});

var app = builder.Build();

app.UseStaticFiles();
app.MapBlazorHub();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware(); 
}
else
{
  app.UseDefaultExceptionHandler(); 
  app.UseHsts();
}
app.UseFastEndpoints();
app.UseSwaggerGen(); 

app.UseHttpsRedirection();

// Seed Database
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  try
  {
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
    SeedData.Initialize(services);
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
  }
}

app.MapFallbackToPage("/_Host");

app.Run();


public partial class Program
{
}
