using Microsoft.Extensions.Configuration;

namespace PharmaWarehouse.Api.Modules.Extensions
{
    public static class ConfigurationExtensions
    {
        public static SensitiveDataConfiguration GetHasSensitiveDataConfiguration(this IConfiguration configuration)
        {
            SensitiveDataConfiguration sensitiveDataConfiguration = new SensitiveDataConfiguration();
            configuration.Bind("SensitiveDataConfiguration", sensitiveDataConfiguration);
            return sensitiveDataConfiguration;
        }

        public static string GetMySqlConnectionString(this IConfiguration configuration)
        {
            var ck = "Sql:Pharmawarehouse:SqLConnection:";

            return $"Host={configuration[$"{ck}Server"]};Port=3306;User={configuration[$"{ck}UserId"]};Password={configuration[$"{ck}Password"]};Database={configuration[$"{ck}Database"]}";
        }
    }
}
