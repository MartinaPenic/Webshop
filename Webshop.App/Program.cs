using Webshop.App.Helpers;
using Webshop.App.Services;
using Webshop.App.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region Services

builder.Services.AddHttpClient<IProductService, ProductService>(c => c.BaseAddress = new Uri("https://localhost:7150/"));
builder.Services.AddHttpClient<IContactService, ContactService>(c => c.BaseAddress = new Uri("https://localhost:7150/"));
builder.Services.AddHttpClient<IShowcaseService, ShowcaseService>(c => c.BaseAddress = new Uri("https://localhost:7150/"));
builder.Services.AddHttpClient<IAccountService, AccountService>(c => c.BaseAddress = new Uri("https://localhost:7150/"));

#endregion

builder.Services.AddScoped<JwtValidation>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
