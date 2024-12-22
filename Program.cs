var builder = WebApplication.CreateBuilder(args);

// Ajoute les services au conteneur
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure le pipeline HTTP de l'application
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ProduitsArtisanaux}/{action=Index}/{id?}");

app.Run();
