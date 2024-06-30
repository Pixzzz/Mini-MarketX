using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Mini_MarketX.Data.Context;
using Mini_MarketX.Data.Interfaces;
using Mini_MarketX.Data.Repositories.Mocks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Mini_MarketXContext>(options => options.UseInMemoryDatabase("MiniMarketXDB"));
builder.Services.AddScoped<IReporteRepository, MockReporteRepository>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

