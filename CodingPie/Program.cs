using CodingPie.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.Add(new ServiceDescriptor(typeof(IPieRepository), typeof(PieRepository), ServiceLifetime.Transient));*/

builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IPieService, PieService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "PieCookie";
        options.LoginPath = "/User/Login";
    });
//builder.Services.AddAuthentication("Session");
/*builder.Services.AddSession(option => {
    option.Cookie.Name = "Pie";
    option.Cookie.IsEssential = true;
    option.Cookie.HttpOnly = true;
    option.IdleTimeout = TimeSpan.FromMinutes(40);
    option.IOTimeout = TimeSpan.FromMinutes(1);
    
});*/
builder.Services.AddControllersWithViews();

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
//app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pie}/{action=Pies}/{id?}");

app.Run();
