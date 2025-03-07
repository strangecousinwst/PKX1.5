using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PKX.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//250217 adicionei este bloco:
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LAGOSTIM")));



//##########################################################################
//Enable Session.-------------------------------------------------2023-04-28
//é necessário adicionar a linha app.UseSession antes
//da app.MapControllerRoute ao fundo



builder.Services.AddSession();









var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");// app.UseExceptionHandler("/Publica/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();










//####################################################################
// projeto cli23: para eventual consulta
//using PKX.Data;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using PKX.Data;

//var builder = WebApplication.CreateBuilder(args);
//// Add services to the container.
//builder.Services.AddControllersWithViews();



//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("LAGOSTIM")));



//var app = builder.Build();

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthorization();

//app.UseSession();



//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

////app.MapControllerRoute(
////    name: "Home",
////    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();