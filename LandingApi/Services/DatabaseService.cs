using Microsoft.Extensions.Options;
using LandingApi.Config;

namespace LandingApi.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IOptions<SiteSettings> settings)
        {
            _connectionString = settings.Value.ConnectionStrings.SanadyarDbTemplate.Replace("{year}", "1404"); // بعداً داینامیک کن
        }

        public string GetConnectionString() => _connectionString;
    }
}
