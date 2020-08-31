using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System.Linq;
using Serilog;

namespace PatternForCore.Web.Extensions
{
    internal static class RuntimeExtensions
    {
        internal static void UseLogger(this IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var configuration = app.ApplicationServices.GetRequiredService<IConfiguration>();

            LogContext.PushProperty("Environment", env.EnvironmentName);
            Log.ForContext<Startup>().Information(
                "Sql=>{connectionString}",
                $"{configuration.GetConnectionString("DefaultConnection").Split(";").First()}");
            Log.ForContext<Startup>()
                .Information("<{EventID:l}> Configure Started {Application} with {@configuration}",
                    "Startup", env.ApplicationName, configuration);

            loggerFactory.AddSerilog(Log.Logger);
        }
    }
}
