using Microsoft.Extensions.Options;
using LandingApi.Config;

namespace LandingApi.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IOptions<ApiSettings> options)
        {
            var template = options.Value.SanadyarDbTemplate;
            var currentYear = "1404"; // بعداً داینامیک کن
            _connectionString = template.Replace("{year}", currentYear);
        }

        public string GetConnectionString() => _connectionString;
    }
}
