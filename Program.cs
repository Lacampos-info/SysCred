using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SysCred.Models;
using SysCred.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adicionando suporte ao ASP.NET Core Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configurando pol�ticas de autoriza��o
builder.Services.AddAuthorization(options => {
    options.AddPolicy("RequireAdminRole",
        policy => policy.RequireRole("Admin"));
});

// Adicionando o servi�o de contexto de banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Habilita o middleware de autentica��o
app.UseAuthorization();  // Habilita o middleware de autoriza��o

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
