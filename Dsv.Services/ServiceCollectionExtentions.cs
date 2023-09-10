using Dsv.Contracts.FilmOps;
using Dsv.Contracts.PeopleOps;
using Dsv.Services.Data;
using Dsv.Services.Impl.PeopleOps;
using Microsoft.Extensions.DependencyInjection;

namespace Dsv.Services
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection RegisterServiceInterfaces(this IServiceCollection services)
        {
            services.AddTransient<IDsvServiceDbContext, DsvServiceDbContext>();

            services.AddScoped<IPeopleOps, PeopleOps>();
            services.AddScoped<IFilmOps, FilmOps>();            

            return services;
        }
    }
}
