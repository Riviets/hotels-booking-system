using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using lab1.Models;
using lab1.DBContext;


var builder = WebApplication.CreateBuilder(args);

// Додайте рядок підключення до бази даних
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Додайте Identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Додайте MVC з підтримкою Areas
builder.Services.AddControllersWithViews();

// Налаштування Razor Pages, якщо потрібно
builder.Services.AddRazorPages();

var app = builder.Build();

// Налаштування конвеєра запитів
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // Додайте аутентифікацію
app.UseAuthorization();

// Налаштування для MVC з підтримкою Areas
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Якщо використовуєте Razor Pages

// Ініціалізація бази даних
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    try
    {
        await dbContext.Database.EnsureCreatedAsync();
        // Тут ви можете виконати запит до бази даних
        var hotelsCount = await dbContext.Hotels.CountAsync();
        Console.WriteLine($"Total hotels in database: {hotelsCount}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while connecting to the database: {ex.Message}");
    }
}

app.Run();
