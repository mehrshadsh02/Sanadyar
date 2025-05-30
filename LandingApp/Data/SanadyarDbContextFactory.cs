using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace LandingApp.Data
{
    public class SanadyarDbContextFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public SanadyarDbContextFactory(IHttpContextAccessor accessor, IConfiguration config)
        {
            _httpContextAccessor = accessor;
            _configuration = config;
        }

        public SanadyarDbContext CreateDbContext()
        {
            var year = _httpContextAccessor.HttpContext?.Request.Query["year"].FirstOrDefault() ?? "1404";
            var connectionStringTemplate = _configuration.GetConnectionString("SanadyarDbTemplate");
            var finalConnStr = connectionStringTemplate.Replace("{year}", year);

            var options = new DbContextOptionsBuilder<SanadyarDbContext>()
                .UseSqlServer(finalConnStr)
                .Options;

            return new SanadyarDbContext(options);
        }
    }
}
