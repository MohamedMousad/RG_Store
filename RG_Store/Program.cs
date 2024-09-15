using EmployeeSystem.DAL.Repo.Abstraction;
using EmployeeSystem.DAL.Repo.Implementation;
using Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RG_Store.BLL.Mapping;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Implementation;
using RG_Store.DAL.DB;
using RG_Store.DAL.Repo.Abstraction;
using RG_Store.DAL.Repo.Implementation;
public class Program
{
    public int user_authority = 1;
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register AutoMapper with the DomainProfile
        builder.Services.AddAutoMapper(typeof(DomainProfile));

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Identity
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("name=DefaultConnection"));

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/SignIn";
                options.AccessDeniedPath = "/Account/SignIn";
            });

        builder.Services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 0;
        }).AddEntityFrameworkStores<ApplicationDbContext>();

        // Register Repositories
        builder.Services.AddScoped<IItemRepo, ItemRepo>();
        builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
        builder.Services.AddScoped<IUserRepo, UserRepo>();
        builder.Services.AddScoped<ICartRepo, CartRepo>();
        builder.Services.AddScoped<IOrderRepo, OrderRepo>();
        builder.Services.AddScoped<IFavouriteRepo, FavouriteRepo>();

        // Register Services
        builder.Services.AddScoped<IItemService, ItemService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ICartService, CartService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IFavouriteService, FavouriteService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
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
