using LandingApp.Data;
using LandingApp.Services;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// بارگذاری .env
DotNetEnv.Env.Load();
var apiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL");
var useAuth = Environment.GetEnvironmentVariable("USE_AUTH") == "true";

// ثبت تنظیمات env به صورت Singleton
builder.Services.AddSingleton(new AppLinks
{
    FinanceApp = Environment.GetEnvironmentVariable("FINANCE_APP"),
    SalaryApp = Environment.GetEnvironmentVariable("SALARY_APP"),
    InventoryApp = Environment.GetEnvironmentVariable("INVENTORY_APP"),
    CashApp = Environment.GetEnvironmentVariable("CASH_APP"),
    ReportApp = Environment.GetEnvironmentVariable("REPORT_APP")
});


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
    options.UseSqlServer(builder.Configuration.GetConnectionString("SanadyarDB")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();
