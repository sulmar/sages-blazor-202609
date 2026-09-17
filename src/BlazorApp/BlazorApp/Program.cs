using BlazorApp;
using BlazorApp.Client.Pages;
using BlazorApp.Components;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure.Fakers;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//builder.Services.AddSingleton<CustomerFaker>();
//builder.Services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
//builder.Services.AddSingleton<IEnumerable<Customer>>(p => p.GetRequiredService<CustomerFaker>().Generate(10));

//builder.Services.AddSingleton<ProductFaker>();
//builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
//builder.Services.AddSingleton<IEnumerable<Product>>(p => p.GetRequiredService<ProductFaker>().Generate(10));

builder.Services.AddInfrastructure();


builder.Services.AddScoped<CascadingValueSource<Profile>>(_ =>
    new CascadingValueSource<Profile>(
        new Profile { Theme = "dark", Size = 12 },
        isFixed: false));

builder.Services.AddCascadingValue<Profile>(sp =>
    sp.GetRequiredService<CascadingValueSource<Profile>>());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp.Client._Imports).Assembly);

app.Run();
