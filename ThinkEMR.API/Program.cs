using Microsoft.EntityFrameworkCore;
using ThinkEMR_Care.Core.Services.IServices.IDeveloperInformationServices;
using ThinkEMR_Care.Core.Services.Services.DeveloperInformationServices;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Repository.IRepository.IDeveloperDetailsRepository;
using ThinkEMR_Care.DataAccess.Repository.RepositoryServices.DeveloperDetailsRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Services Repository as well as Interface and service Layer
builder.Services.AddScoped<IDeveloperDetailsRepository,DeveloperDetailsRepository>();

builder.Services.AddScoped<IDeveloperInfoService, DeveloperInfoServices>();

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
