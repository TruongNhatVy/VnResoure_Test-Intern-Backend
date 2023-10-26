using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VnResoure_Test_Intern_Backend.AutoMapperProfile;
using VnResoure_Test_Intern_Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register service for Dependency Injection container
builder.Services.AddTransient<VNR_InternShipContext>();
builder.Services.AddTransient<MappingProfile>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
