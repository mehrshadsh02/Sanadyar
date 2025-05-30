using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LandingApp.Data;

namespace LandingApp.Services
{
    public class DynamicDbContextFactory
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IConfiguration _configuration;

        public DynamicDbContextFactory(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            _configuration = configuration;
        }

        public SanadyarDbContext CreateDbContext()
        {
            var year = _accessor.HttpContext?.Session.GetInt32("FiscalYear") ?? 1404;
            var connectionString = _configuration.GetConnectionString($"SanadyarDb_{year}");

            var optionsBuilder = new DbContextOptionsBuilder<SanadyarDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SanadyarDbContext(optionsBuilder.Options);
        }
    }
}
