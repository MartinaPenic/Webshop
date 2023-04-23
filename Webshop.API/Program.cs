using api.infrastructure.filters;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Webshop.API.Context;
using Webshop.API.Filters;
using Webshop.API.Mapper;
using Webshop.API.Repositories;
using Webshop.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DataContext>(ob => ob.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<MessageRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<MessageService>();

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "V1" });
    config.OperationFilter<ApiHeaderParameter>();
});

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

// Middleware registration before authorization
app.UseMiddleware<ApiKeyMiddleware>();  
app.UseAuthorization();

app.MapControllers();

app.Run();
