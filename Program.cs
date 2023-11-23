using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prod_Manger.Data;
using Prod_Manger.Repository;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProdManagerDbContext>(options =>
                              options.UseSqlServer(builder.Configuration.GetConnectionString("ProdManagerConnectionString")));

builder.Services.AddTransient<ProdManagerDbContext, ProdManagerDbContext>();
builder.Services.AddTransient<ProductsRepository, ProductsRepository>();
builder.Services.AddSession();



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
