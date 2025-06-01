using Microsoft.EntityFrameworkCore;
using VideotecaApp.Data;
using VideotecaApp.Repositorio.Interfaces;
using VideotecaApp.Repositorio.Implementaciones;
using VideotecaApp.Components;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); 


builder.Services.AddDbContext<VideotecaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddScoped<IRepositorioPelicula, RepositorioPelicula>();
builder.Services.AddScoped<IRepositorioRenta, RepositorioRenta>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();
app.UseAntiforgery(); 

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
