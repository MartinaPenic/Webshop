using Webshop.App.Services;
using Webshop.App.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IProductService, ProductService>(c => c.BaseAddress = new Uri("https://localhost:7150/"));
builder.Services.AddHttpClient<IContactService, ContactService>(c => c.BaseAddress = new Uri("https://localhost:7150/"));
builder.Services.AddHttpClient<IShowcaseService, ShowcaseService>(c => c.BaseAddress = new Uri("https://localhost:7150/"));

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
