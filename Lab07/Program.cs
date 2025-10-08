using InClass07.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();               // keep Razor Pages
builder.Services.AddControllersWithViews();     // enable MVC controllers + views

builder.Services.AddDbContext<K64cnt2dbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")));

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

app.UseAuthorization();

// MVC routes (default to SanPhams)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SanPhams}/{action=Index}/{id?}");

// Razor Pages (if you have any)
app.MapRazorPages();

app.Run();
