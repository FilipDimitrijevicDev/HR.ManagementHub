using Core.Application.Common.Email;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Application.Common.Models;
using Core.Domain;
using Core.Infrastructure.Persistence.EmailService;
using Core.Infrastructure.Persistence.Logging;
using Core.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Persistence;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext.DatabaseContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<ILeaveDistributionRepository, LeaveDistributionRepository>();

        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();

        services.AddScoped(typeof(ILogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}
