using Microsoft.EntityFrameworkCore;
using ThinkEMR_Care.Core.Services;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Repository.ProviderRepository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProvidersRepository, ProvidersRepository>();
builder.Services.AddScoped<IProvidersService, ProvidersService>();



builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

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
