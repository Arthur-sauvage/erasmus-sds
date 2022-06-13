using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using SDS.Data;
using SDS.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SDSAuthContextConnection");;

builder.Services.AddDbContext<SDSAuthContext>(options =>
    options.UseSqlite(connectionString));;

builder.Services.AddDefaultIdentity<SDSUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireDigit = false;
}
        )
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SDSAuthContext>();
    
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<SDSContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("SDSContext")));
}
else
{
    builder.Services.AddDbContext<SDSContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionSDSContext")));
}

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Courses}/{action=Index}/{id?}");

app.UseEndpoints(endpoints => endpoints.MapRazorPages());

app.Run();
