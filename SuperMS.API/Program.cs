using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Smarti.Services;
using Smarti.Services.Interfaces;
using SuperMS.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
.Build();


builder.Services.AddDbContext<CategoriesContext>(options=>options.UseSqlite(configuration.GetConnectionString("SQLiteConnection"), b => b.MigrationsAssembly("SuperMS.API")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<ID2Service, D2Service>();
builder.Services.AddScoped<IWebIntService, WebIntService>();
//builder.Services.AddScoped<IGeneralServices, GeneralServices>();


// Add memory cache service
builder.Services.AddMemoryCache();


///
//builder.Services.AddTransient<GeneralServices>();

// Retrieve data and cache it during startup
//var myService = builder.Services.BuildServiceProvider().GetService<GeneralServices>();
//string data = myService.GetData("PrioritiesData");

///
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CategoriesContext>();
    dbContext.Database.Migrate();
   // dbContext.SeedData();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

