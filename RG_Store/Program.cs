using EmployeeSystem.DAL.Repo.Abstraction;
using EmployeeSystem.DAL.Repo.Implementation;
using Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RG_Store.BLL.Mapping;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Implementation;
using RG_Store.DAL.DB;
using RG_Store.DAL.Repo.Abstraction;
using RG_Store.DAL.Repo.Implementation;
using RG_Store.Services.Implementation;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAutoMapper(typeof(DomainProfile));

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            options =>
            {
                options.LoginPath = new PathString("/Account/SignIn");
                options.AccessDeniedPath = new PathString("/Account/SignIn");
            });


        builder.Services.AddScoped<SignInManager<User>>();



        builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
                                .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<ApplicationDbContext>()
                        .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);
        builder.Services.AddIdentity<User, IdentityRole>(options =>
        {
            // Allow any password with at least one character
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 1; // Minimum 1 character
            options.Password.RequiredUniqueChars = 0; // No unique character requirement
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        builder.Services.AddScoped<UserManager<User>, CustomUserManager>();


        builder.Services.AddScoped<IUserService, UserService>();


        builder.Services.AddScoped<CustomUserManager>();


        builder.Services.AddScoped<CustomUserManager>();
        builder.Services.AddScoped<UserService>();



        
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



        using (var scope = app.Services.CreateScope())
        {
                var rolesManger =
                scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new[] { "Admin", "Customer" };

            foreach(var role in roles)
            {
                if(! await rolesManger.RoleExistsAsync(role))
                    await rolesManger.CreateAsync(new  IdentityRole(role));
            }
        }
        using(var scope = app.Services.CreateScope())
        {
                var userManger =
                scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            string email = "Admin@admin.com";
            string password = "adminadmin123";
            if (await userManger.FindByEmailAsync(email) == null)
            {
                User user = new();
                user.Email = email; 
                user.UserName = email;
                user.EmailConfirmed = true;
                user.IsDeleted = false;
                user.UserGender = RG_Store.DAL.Enums.Gender.Male;
                user.FirstName = user.LastName = "Admin";
                user.UserRole = RG_Store.DAL.Enums.Roles.Admin; 
                await  userManger.CreateAsync(user, password);
                await userManger.AddToRoleAsync(user,"Admin");
            }
        }

        app.Run();
    }
}
