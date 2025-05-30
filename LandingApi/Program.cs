using LandingApi.Config;
using LandingApi.Services;


var builder = WebApplication.CreateBuilder(args);

// ✳️ 1. Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✳️ 2. تنظیم پورت
builder.WebHost.UseUrls("http://localhost:8100");

builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddSingleton<DatabaseService>();




var app = builder.Build();

// ✳️ 3. فعال‌سازی Swagger در حالت توسعه
//if (app.Environment.IsDevelopment())

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
