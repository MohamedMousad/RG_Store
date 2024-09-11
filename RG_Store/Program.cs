using EmployeeSystem.DAL.Repo.Abstraction;
using EmployeeSystem.DAL.Repo.Implementation;
using Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RG_Store.DAL.DB;
using RG_Store.DAL.Repo.Abstraction;
using RG_Store.DAL.Repo.Implementation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("name=DefaultConnection"));


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.LoginPath = new PathString("/Account/SignIn");
        options.AccessDeniedPath = new PathString("/Account/SignIn");
    });


//builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
//                .AddEntityFrameworkStores<ApplicationDbContext>()
//                .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
 /*   //options.User.RequireUniqueEmail = true;
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;*/
}).AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddScoped<IItemRepo, ItemRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ICartRepo, CartRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IFavouriteRepo, FavouriteRepo>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
