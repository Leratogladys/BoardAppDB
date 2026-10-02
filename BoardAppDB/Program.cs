// Programmer name : BoardAppDB Group
// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Assignment nr   : Practical Assessment 2
// Purpose         : Configures application services, dependency injection,
//                   middleware, routing and database initialization.

using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BoardContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDBInitializer, DBInitializerRepo>();
builder.Services.AddScoped<IBoard, BoardRepo>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider
        .GetRequiredService<IDBInitializer>();

    dbInitializer.Initialize();
} // end using

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
} // end if

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
