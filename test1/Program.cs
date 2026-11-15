using Microsoft.EntityFrameworkCore;
using test1.Models;

var builder = WebApplication.CreateBuilder(args);
var cn = builder.Configuration.GetConnectionString("cn")
    ?? builder.Configuration.GetConnectionString("ProvinciasDbContext")
    ?? throw new InvalidOperationException("No se configuró una cadena de conexión para la base de datos.");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProvinciasDbContext>(options =>
    options.UseNpgsql(cn));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Clientes}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
