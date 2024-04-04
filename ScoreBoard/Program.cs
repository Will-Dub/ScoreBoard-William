using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScoreBoard.Models;
using ScoreBoard.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IJeuRepository, BDJeuRepository>();
builder.Services.AddScoped<IJoueurRepository, BDJoueurRepository>();

builder.Services.AddDbContext<CatalogueJoueurDbContext>(options =>
  {
      options.UseSqlServer(builder.Configuration["ConnectionStrings:CatalogueJeuxDbContextConnection"]);
  });

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

InitialiseurBD.Seed(app);

app.Run();
