using Microsoft.AspNetCore.Authentication.Cookies;
using MVC.Service;
using MVC.Service.IService;
using MVC.Utility;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();
            builder.Services.AddHttpClient<IBasketService, BasketService>();
            builder.Services.AddHttpClient<ICatalogService, CatalogService>();
            builder.Services.AddHttpClient<IAuthService, AuthService>();
            SD.AuthApiBase = builder.Configuration["ServiceUrls:IdentityApi"];
            SD.CatalogApiBase = builder.Configuration["ServiceUrls:CatalogApi"];
            SD.BasketApiBase = builder.Configuration["ServiceUrls:BasketApi"];
            SD.OrderApiBase = builder.Configuration["ServiceUrls:OrderApi"];

            builder.Services.AddScoped<IBaseService, BaseService>();
            builder.Services.AddScoped<ITokenProvider, TokenProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ICatalogService, CatalogService>();
            builder.Services.AddScoped<IBasketService, BasketService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromHours(10);
                    options.LoginPath = "/Auth/Login";
                    options.AccessDeniedPath = "/Auth/AccessDenied";
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); 
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}