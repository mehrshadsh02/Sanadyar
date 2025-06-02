using LandingApp.Data;
using LandingApp.Services;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// بارگذاری .env
DotNetEnv.Env.Load();

builder.Services.AddSingleton(new AppLinks
{
    FinanceApp = Environment.GetEnvironmentVariable("FINANCE_APP"),
    SalaryApp = Environment.GetEnvironmentVariable("SALARY_APP"),
    InventoryApp = Environment.GetEnvironmentVariable("INVENTORY_APP"),
    CashApp = Environment.GetEnvironmentVariable("CASH_APP"),
    ReportApp = Environment.GetEnvironmentVariable("REPORT_APP"),
    TablesApp = Environment.GetEnvironmentVariable("TABLES_APP")
});

// پیکربندی دیتاپروتکشن برای تولید
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("D:/mehrshad/keys"))
    .SetApplicationName("Sanadyar");

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<SanadyarDbContextFactory>();
builder.Services.AddSession();
builder.Services.AddScoped<DynamicDbContextFactory>();

builder.Services.AddScoped(sp =>
{
    var factory = sp.GetRequiredService<SanadyarDbContextFactory>();
    return factory.CreateDbContext();
});

builder.Services.AddAuthentication("MyCookie")
    .AddCookie("MyCookie", options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });

builder.Services.AddDbContext<SanadyarDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SanadyarDbTemplate")));

var app = builder.Build();


try
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<SanadyarDbContext>();
    Console.WriteLine(db.Database.CanConnect() ? "✅ اتصال موفق" : "❌ اتصال شکست خورد");
}
catch (Exception ex)
{
    Console.WriteLine("❌ خطای دیتابیس در زمان اجرا: " + ex.Message);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");



app.Run();