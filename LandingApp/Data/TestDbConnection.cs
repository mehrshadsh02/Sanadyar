using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using LandingApp.Data;

class Test
{
    static void Main()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = builder.GetConnectionString("SanadyarDbTemplate");
        var options = new DbContextOptionsBuilder<SanadyarDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        try
        {
            using var db = new SanadyarDbContext(options);
            var canConnect = db.Database.CanConnect();
            Console.WriteLine(canConnect ? "✅ اتصال موفق بود" : "❌ اتصال برقرار نشد");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ خطا در اتصال:");
            Console.WriteLine(ex.Message);
        }
    }
}
