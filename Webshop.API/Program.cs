using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Webshop.API.Authentication;
using Webshop.API.Context;
using Webshop.API.Filters;
using Webshop.API.Mapper;
using Webshop.API.Models;
using Webshop.API.Models.Entities;
using Webshop.API.Repositories;
using Webshop.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<JwtToken>();

#region Contexts

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

#endregion

#region Repositories

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<MessageRepository>();
builder.Services.AddScoped<ShowcaseRepository>();
builder.Services.AddScoped<UserProfileRepository>();

#endregion

#region Services

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<Microsoft.AspNetCore.Authentication.AuthenticationService>();

#endregion

#region Swagger

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "V1" });
    config.OperationFilter<ApiHeaderParameter>();
});

#endregion

#region Maper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

#region Identity

builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>(options =>
{ options.User.RequireUniqueEmail = true; })
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

#endregion

#region Authentication

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            if (string.IsNullOrEmpty(context?.Principal?.FindFirst("id")?.Value) || string.IsNullOrEmpty(context?.Principal?.Identity?.Name))
                context?.Fail("Unauthorized");

            return Task.CompletedTask;
        }
    };

    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenValidation").GetValue<string>("SecretKey")!)),
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration.GetSection("TokenValidation").GetValue<string>("Issuer"),
        ValidateAudience = true,
        ValidAudience = builder.Configuration.GetSection("TokenValidation").GetValue<string>("Audience"),
        ClockSkew = TimeSpan.FromSeconds(0),
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole(UserRole.Admin.ToString()));
    options.AddPolicy("ProductManagerOnly", policy => policy.RequireRole(UserRole.ProductManager.ToString()));
});

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();
app.UseMiddleware<ApiKeyMiddleware>();  
app.UseAuthorization();
app.MapControllers();
app.Run();
