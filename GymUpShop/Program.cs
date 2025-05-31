using GymUpShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/*-----Service Collections -  Dependency injection ------*/

//Conectandose a la Base de Dato 
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();

/* Trabajando con Data en Duro -Mock Version -
 
builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IEquipmentRepository, MockEquipmentRepository>();

*/


builder.Services.AddControllersWithViews();   //ASP.NET Core MVC
                                             // Conexion to BD
builder.Services.AddDbContext<GymUpShopDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:GymUpShopDbContextConnection"]);
});



/*-----Middleware Components--------*/
var app = builder.Build();

app.UseStaticFiles();   //wwwroot

if (app.Environment.IsDevelopment())   //Para ver What is wrong? solo en ambiente Desarrollo. se activa Pag de Excepciones.
{
    app.UseDeveloperExceptionPage();
}

//Permite la navegacion
app.MapDefaultControllerRoute();  // "{controller=Home}/{action=Index}/{id?}"

//Haciendo el Routing Manualmente, es mejor usar el Default Route, 1 linea arriba, solo hacer manual si desea un routing muy personalizado. pero la mayoria usa el MapDefaultControllerRouting
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

DbInitializer.Seed(app);    //Clase DbInitializer ( es un nombre no convencional, es cualquier nombre para esta clase el cual tiene 1 solo metodo llamado Seed, Metodo Seed sirve Carga data de Inicio a la Base de Dato, verifica si no hay data inserta, si hay no hace nada.)

app.Run();
