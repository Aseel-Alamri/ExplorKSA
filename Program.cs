using FinalWebApplication.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext for ApplicationDbContext (already in your code)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add distributed memory cache for session storage
builder.Services.AddDistributedMemoryCache();

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Set session timeout duration (adjust as needed)
    options.Cookie.HttpOnly = true;  // Ensures cookies are accessible only to the server
    options.Cookie.IsEssential = true;  // Marks session cookie as essential (i.e., it will not be blocked by cookie consent settings)
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Enable session middleware
app.UseSession();  // This must be called before UseAuthorization

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
