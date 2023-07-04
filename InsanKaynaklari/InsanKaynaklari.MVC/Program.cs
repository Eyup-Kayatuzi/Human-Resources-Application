using InsanKaynaklari.Domain.EMailManagement.Configuration;
using InsanKaynaklari.Domain.EMailManagement.Service;
using InsanKaynaklari.Domain.Identity;
using InsanKaynaklari.MVC;
using InsanKaynaklari.Persistence;
using InsanKaynaklari.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddPersistenceServices();
builder.Services.AddRazorPages();
builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 2;
}).AddEntityFrameworkStores<InsanKaynaklariDb>().AddDefaultTokenProviders();

builder.Services.AddScoped<IEmailService, EMailService>();
builder.Services.AddSingleton(builder.Configuration.GetSection("EmailConfig").Get<EMailConfig>());

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/UserAuthentication/Login";
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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
