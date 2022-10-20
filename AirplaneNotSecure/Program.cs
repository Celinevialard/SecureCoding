using AirplaneNotSecure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITicketDb, TicketDb>();
builder.Services.AddScoped<IUserDb, UserDb>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.Cookie.SameSite = SameSiteMode.Unspecified;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
