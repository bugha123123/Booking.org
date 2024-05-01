using Hotel.org.ApplicationDBContext;
using Hotel.org.Interface;
using Hotel.org.Models;
using Hotel.org.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelConnectionString")));
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    // Set desired options
    options.Password.RequiredLength = 1; // Set minimum password length to zero
    options.Password.RequireUppercase = false; // Disable uppercase characters requirement
    options.Password.RequireLowercase = false; // Disable lowercase characters requirement
    options.Password.RequireDigit = false; // Disable digit requirement
    options.Password.RequireNonAlphanumeric = false; // Disable non-alphanumeric requirement
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();
// Registering services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IHotelService, HotelService>();
// Registration ends here

builder.Services.AddControllersWithViews();

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
