using Demo_webshop;
using Serilog;
using Serilog.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Demo_webshop.Models;
using System.Text.Json.Serialization;
using Demo_webshop.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Demo_webshop.Models.Services.Helpers;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebShopContextSQLConnection") ?? throw new InvalidOperationException("Connection string 'DemoWebShopDBContextConnection' not found.");

builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCartRepository>(sp => ShoppingCartRepository.GetCart(sp));


builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

builder.Services.AddDbContext<DemoWebShopDBContext>(options =>
{

    options.UseSqlServer(builder.Configuration
    ["ConnectionStrings:WebShopContextSQLConnection"]);

});




builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DemoWebShopDBContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.Strict;
});



builder.Services.AddLogging();
var loggingSection = builder.Configuration.GetSection("Logging");
builder.Services.AddLogging(builder =>
{
    builder.AddConfiguration(loggingSection);
});
builder.Host.UseSerilog((context, loggerconfig) =>
{

    loggerconfig.WriteTo.File(LogPath.Path);


});

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(opt =>
    {

        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

    });

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapDefaultControllerRoute();
//name: "default",
//pattern: "{controller=Home}/{action=Index}/{id:int?}");

app.MapRazorPages();

//app.UseHttpsRedirection();


//app.UseRouting();






app.MapFallbackToPage("/app/[*catchall]", "/App/Index");

app.Run();
