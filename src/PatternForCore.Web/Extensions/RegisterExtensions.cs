using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatternForCore.Core.EFContext;
using PatternForCore.Core.Factory;
using PatternForCore.Core.Repositories.Base;
using PatternForCore.Core.Repositories.Interfaces;
using PatternForCore.Core.Uow;
using PatternForCore.Models.Identity;
using PatternForCore.Services;
using PatternForCore.Services.Base.Contracts;
using System;

namespace PatternForCore.Web.Extensions
{
    internal static class RegisterExtensions
    {
        internal static void AddDbContexts(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var contextConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<DatabaseContext>(x => x.UseSqlServer(contextConnectionString, o =>
                {
                    o.EnableRetryOnFailure(3);
                })
                .EnableSensitiveDataLogging(environment.IsDevelopment())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

        internal static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseContext, DatabaseContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IMovieServices), typeof(MovieServices));
            services.AddTransient<IContextFactory, ContextFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        internal static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = false;
            });
        }
    }
}
