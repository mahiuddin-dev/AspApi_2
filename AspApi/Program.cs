using AspApi.Context;
using AspApi.Interfaces.Manager;
using AspApi.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

//AddTransient: Registers the service as a transient service, which means a new instance of the service is created each time it is requested. This is useful for services that are short-lived and stateless.
builder.Services.AddTransient<iPostManager, PostManager>();

//AddScoped: Registers the service as a scoped service, which means a single instance of the service is created per request. This is useful for services that are designed to be long-lived and stateful within a single request.

// builder.Services.AddScoped<iPostManager, PostManager>();

//AddSingleton: Registers the service as a singleton service, which means a single instance of the service is created and shared across the entire application. This is useful for services that are designed to be long-lived and stateful.

// builder.Services.AddSingleton<iPostManager, PostManager>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
