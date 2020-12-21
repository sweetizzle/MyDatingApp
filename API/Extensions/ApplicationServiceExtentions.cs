using API.Data;
using interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Services;

namespace Extensions
{
    public static class ApplicationServiceExtentions
    {
       public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
            {
                      services.AddScoped<ITokenService1, TokenService>();
           
                IServiceCollection serviceCollections = services.AddDbContext<DataContext>(options =>
                {
                    options.UseSqlite(config.GetConnectionString("DefaultConnection"));
                });
                services.AddControllers();
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                });

                return services;
            }
    }
}