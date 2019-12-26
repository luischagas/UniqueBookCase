using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UniqueBookCase.DomainModel;

namespace UniqueBookCase.Api.Configuration
{
    public static class RabbitMQConfiguration
    {
        public static IServiceCollection ConfigRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMQConfigurations = new RabbitMQConfigurations();

            new ConfigureFromConfigurationOptions<RabbitMQConfigurations>(
                configuration.GetSection("RabbitMQConfigurations"))
                        .Configure(rabbitMQConfigurations);

            services.AddSingleton(rabbitMQConfigurations);

            return services;

        }

    }
}
