using AirplaneSecure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITicketDb, TicketDb>();


var app = builder.Build();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Strict;
});
// add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyCORStest",
                      policy =>
                      {
                          policy.WithOrigins("153.109.124.35",
                                              "http://www.airline.com");
                          policy.WithMethods("POST", "OPTION", "GET");
                          policy.WithHeaders("My-Favorite-Airline");
                          policy.AllowCredentials();
                      });
});
app.UseCors("MyCORStest");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // ajout du Http Strict-Transport-Security
    // par defaut ajouter si on coche à la création
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
