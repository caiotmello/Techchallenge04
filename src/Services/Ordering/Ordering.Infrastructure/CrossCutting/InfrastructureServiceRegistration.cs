using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Models;
using Ordering.Infrastructure.Email;
using Ordering.Infrastructure.Persistence;
using Ordering.Infrastructure.Repositories;

namespace Ordering.Infrastructure.CrossCutting
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.Configure<EmailSettings>(options =>
            {
                options.FromAddress = configuration.GetSection(nameof(EmailSettings))[nameof(EmailSettings.FromAddress)];
                options.ApiKey = configuration.GetSection(nameof(EmailSettings))[nameof(EmailSettings.ApiKey)];
                options.FromName = configuration.GetSection(nameof(EmailSettings))[nameof(EmailSettings.FromName)];

            });
            
            services.AddTransient<IEmailService, EmailService>();

            return services;

        }
    }
}
