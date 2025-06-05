using LandingApi.Config;
using LandingApi.Services;
using Microsoft.Extensions.Options;
using Xunit;

namespace LandingApi.Tests;

public class DatabaseServiceTests
{
    [Fact]
    public void GetConnectionString_ReplacesYearPlaceholder()
    {
        var settings = new ApiSettings { SanadyarDbTemplate = "db_{year}_connection" };
        var service = new DatabaseService(Options.Create(settings));

        var result = service.GetConnectionString();

        Assert.Equal("db_1404_connection", result);
    }
}
