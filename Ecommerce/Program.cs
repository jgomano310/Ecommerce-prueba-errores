using DAL.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Ecommerce.Areas.Identity.Data;
using Ecommerce.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<EcommerceContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection"));
    });

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<LoginContexto>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection"));
    });



builder.Services.AddDefaultIdentity<EcommerceUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LoginContexto>();

AddScope();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
void AddScope()
{
    builder.Services.AddScoped<InterfazUsuario, RepoUsuarios>();
    builder.Services.AddScoped<InterfazRoles, RepoRoles>();
    builder.Services.AddScoped<IunidadDeTrabajo, UnidadDeTrabajoRepo>();
}






























app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
