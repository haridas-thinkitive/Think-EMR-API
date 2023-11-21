using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NETCore.MailKit.Core;
using System.Text;
using ThinkEMR_Care.Core.Services;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.Authentication.CustomData;
using ThinkEMR_Care.DataAccess.Repository;
using ThinkEMR_Care.DataAccess.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

//UserManagementServices
builder.Services.AddScoped<IUserManagement, UserManagementService>();

//builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
//builder.Services.AddScoped<IProviderService, ProviderService>();


builder.Services.AddScoped<IDashboardDetailsCount,DashboardDetailsRepository>();
builder.Services.AddScoped<IDashboardDetails, DashboardDetailsServices>();

builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IAuthenticationServices, AuthenticationServices>();
builder.Services.AddScoped<IEmailSMTP, EmailSMTPServices>();
builder.Services.AddScoped<IEmail, EmailServices>();

//Sagar Services
builder.Services.AddScoped<ICPCTCodeCatalog,CPCTCodeCatalogServices>();
builder.Services.AddScoped<ICPCTCodeCatalogRepository,CPCTCodeCatalogRepository>();

builder.Services.AddScoped<IDataImportRepository, DataImportRepository>();
builder.Services.AddScoped<IDataImportServices, DataImportServices>();

builder.Services.AddScoped<IDrugCatalogRepository, DrugCatalogRepository>();
builder.Services.AddScoped<IDrugCatalogServices, DrugCatalogServices>();

builder.Services.AddScoped<IHCPCSCodeCatalogRepository, HCPCSCodeCatalogRepository>();
builder.Services.AddScoped<IHCPCSCodeCatalogServices, HCPCSCodeCatalogServices>();

builder.Services.AddScoped<IICD10CodeCatalogRepository, ICD10CodeCatalogRepository>();
builder.Services.AddScoped<IICD10CodeCatalogServices , ICD10CodeCatalogServices>();

builder.Services.AddScoped<ILOINCCodeRepository, LOINCCodeRepository>();
builder.Services.AddScoped<ILOINCCodeServices, LOINCCodeServices>();

//Vishal
builder.Services.AddScoped<IRolesAndResponsibilityRepository, RolesAndResponsibilityRepository>();
builder.Services.AddScoped<IRolesAndResponsibilityService, RolesAndResponsibilityService>();

//Anup

builder.Services.AddScoped<IProviderGroupsRepository , ProviderGroupsRepository>();
builder.Services.AddScoped<IProviderGroupsService , ProviderGroupsService>();

builder.Services.AddScoped<ILocationsRepository,LocationsRepository>();
builder.Services.AddScoped<ILocationsService, LocationsService>();

builder.Services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
builder.Services.AddScoped<IDepartmentsService, DepartmentsService>();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersServices, UsersServices>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddHttpContextAccessor();
var configuration = builder.Configuration;

//Dababase Connectionstrng

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//For Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options => options.SignIn.RequireConfirmedEmail=true);

//Add Email Configuration
var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

//For Token Lifesapn Configuration
builder.Services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromMinutes(10));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options
.WithOrigins("http://localhost:7084")
.AllowAnyMethod()
.AllowCredentials()
.AllowAnyHeader()

);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
