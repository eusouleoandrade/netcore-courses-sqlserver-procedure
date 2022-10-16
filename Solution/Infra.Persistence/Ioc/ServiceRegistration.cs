using Core.Application.Interfaces.Repositories;
using Infra.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Persistence.Ioc
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepositoryAsync<,>), typeof(GenericRepositoryAsync<,>));
            services.AddScoped<IDurationMinutesCoursesRepository, DurationMinutesCoursesRepository>();
        }
    }
}