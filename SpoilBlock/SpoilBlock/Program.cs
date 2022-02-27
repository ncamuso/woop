using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.DAL.Concrete;
using SpoilBlock.Data;
using SpoilBlock.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//This needs to be replaced with a line that gets the key from an Azure Key Vault!!
builder.Services.AddSingleton<IIMDbSearchService>(s => new IMDbSearchService(builder.Configuration["IMDb:ServiceApiKey"]));

//var connectionString = builder.Configuration.GetConnectionString("WOOPServerConnection"); builder.Services.AddDbContext<WOOPDbContext>(options =>
//    options.UseSqlServer(connectionString));

//var identityConnectionString = builder.Configuration.GetConnectionString("WOOPIdentityServerConnection"); builder.Services.AddDbContext<IdentityDbContext>(options =>
//     options.UseSqlServer(identityConnectionString)); builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//      .AddEntityFrameworkStores<IdentityDbContext>();
var connectionString = builder.Configuration.GetConnectionString("WOOPConnection"); builder.Services.AddDbContext<WOOPDbContext>(options =>
    options.UseSqlServer(connectionString));

var identityConnectionString = builder.Configuration.GetConnectionString("IdentityDbContextConnection"); builder.Services.AddDbContext<IdentityDbContext>(options =>
     options.UseSqlServer(identityConnectionString)); builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
      .AddEntityFrameworkStores<IdentityDbContext>();



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
app.MapRazorPages();

app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();

                });


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
