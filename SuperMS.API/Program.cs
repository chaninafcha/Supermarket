using Microsoft.EntityFrameworkCore;
using SuperMS.Application.Repository;
using SuperMS.Application.Repository.Interface;
using SuperMS.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
.Build();

var a = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CategoriesContext>(options=>options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SuperMS.Domain")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IProductsService),typeof(ProductService));
builder.Services.AddScoped(typeof(ICategoriesService),typeof(CategoriesService));
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Add memory cache service
builder.Services.AddMemoryCache();


///


///
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CategoriesContext>();
    dbContext.Database.Migrate();
     dbContext.SeedData();
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

