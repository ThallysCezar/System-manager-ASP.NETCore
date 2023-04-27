using CarRental.Data;
using CarRental.Services;
using CarRental.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringMySql = builder.Configuration.GetConnectionString("ConectionMyAPI");
builder.Services.AddDbContext<CarRentalContext>(options => options.UseMySql(
    connectionStringMySql,
    ServerVersion.Parse("8.0.32-MySQL"))
);

builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IRentalRecordService, RentalRecordService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddControllersWithViews();


var app = builder.Build();

SeedingService.PrePopulation(app);

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
