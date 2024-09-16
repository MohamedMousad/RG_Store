using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RG_Store.BLL.Mapping;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Implementation;
using RG_Store.DAL.DB;
using RG_Store.DAL.Repo.Abstraction;
using RG_Store.DAL.Repo.Implementation;
using Entities;
using EmployeeSystem.DAL.Repo.Abstraction;
using EmployeeSystem.DAL.Repo.Implementation;
using RG_Store.Services.Implementation;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAutoMapper(typeof(DomainProfile));

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<SignInManager<User>>();
        builder.Services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 0;
            options.SignIn.RequireConfirmedEmail = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        builder.Services.AddScoped<UserManager<User>, CustomUserManager>();


        builder.Services.AddScoped<IUserService, UserService>();


        builder.Services.AddScoped<CustomUserManager>();


        builder.Services.AddScoped<CustomUserManager>();
        builder.Services.AddScoped<UserService>();



        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/SignIn";
                options.AccessDeniedPath = "/Account/SignIn";
            });

        builder.Services.AddScoped<IItemRepo, ItemRepo>();
        builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
        builder.Services.AddScoped<IUserRepo, UserRepo>();
        builder.Services.AddScoped<ICartRepo, CartRepo>();
        builder.Services.AddScoped<IOrderRepo, OrderRepo>();
        builder.Services.AddScoped<IFavouriteRepo, FavouriteRepo>();

        builder.Services.AddScoped<IItemService, ItemService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();


        builder.Services.AddScoped<ICartService, CartService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IFavouriteService, FavouriteService>();

        builder.Services.AddScoped<IEmailService, EmailService>();

        var app = builder.Build();

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
