using Microsoft.Extensions.DependencyInjection;
using LiteDB_Example.Services;

namespace LiteDB_Example.Common
{
    public static class LiteDBExtentions
    {
        public static IServiceCollection AddLiteDBContext(this IServiceCollection services, string databasePath)
        {
            services.AddTransient<ILiteDBContext, LiteDBContext>();
            services.Configure<Configs>(options => options.PathToDB = databasePath);

            return services;

        }

        public static void AddLiteDbService(this IServiceCollection services)
        {
            services.AddTransient<ILiteDBServices, LiteDBServices>();
        }
    }
}
