using GestionPaieApi.Data;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using GestionPaieApi.Repositories;
using GestionPaieApi.Reposotories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Db_context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Scoped services
builder.Services.AddScoped<GenericRepository<Employe>, GenericRepository<Employe>>();
builder.Services.AddScoped<GenericRepository<LettreAccompagnee>, GenericRepository<LettreAccompagnee>>();
builder.Services.AddScoped<GenericRepository<Pointage>, GenericRepository<Pointage>>();
builder.Services.AddScoped<IBulletinSalaireRepo, BulletinSalaireRepo>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Migrate and seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var context = services.GetRequiredService<Db_context>();
        context.Database.Migrate();
        SeedData.Initialize(context);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();