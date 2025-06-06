using LandingApi.Config;
using LandingApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 🟢 Load Configuration Sections
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
builder.Services.Configure<SiteSettings>(builder.Configuration.GetSection("SiteSettings"));
builder.Services.Configure<HttpBaseUrls>(builder.Configuration.GetSection("HttpBaseUrls"));
builder.Services.Configure<SiteSettings>(builder.Configuration.GetSection("SiteSettings"));


// 🟢 Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DatabaseService>();

// 🟢 Custom Port (Optional – remove if handled by IIS)
builder.WebHost.UseUrls("http://localhost:8100");

var app = builder.Build();

// 🟢 Swagger
app.UseSwagger();
app.UseSwaggerUI();

// 🔒 Middleware (در آینده: احراز هویت، Logging و ...)
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
