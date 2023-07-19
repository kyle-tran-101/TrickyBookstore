using Application.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            string conn = configuration.GetConnectionString(Constants.BookstoreDatabase);
            if (conn.Contains(Constants.ContentRootPlaceholder))
            {
                conn = conn.Replace(Constants.ContentRootPlaceholder, Constants.ContentRootPath);
            }
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(conn,
                b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)), ServiceLifetime.Transient);
            services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());
            return services;
        }
    }
}