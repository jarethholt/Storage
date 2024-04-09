﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Storage.Data;

// The builder is what's used to register services
// It then handles the dependency injection needed to build the app
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StorageContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("StorageContext")
        ?? throw new InvalidOperationException("Connection string 'StorageContext' not found.")
    ));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // From PluralSight course: get more information on exceptions when in developer mode
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();  // Redirect http requests to https
app.UseStaticFiles();  // Keep static files in wwwroot to short-circuit middleware pipeline

app.UseRouting();  // Determine where requests should go

app.UseAuthorization();  // Enable authorization of users

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // Pattern specifies how to translate a URL into an endpoint/request

// Primary function that starts the server and runs the application
app.Run();
