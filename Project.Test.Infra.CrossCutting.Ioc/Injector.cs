using Microsoft.Extensions.DependencyInjection;
using Project.Test.Application.Service.Interface;
using Project.Test.Application.Service.Service;
using Project.Test.Domain.Interfaces.Repository;
using Project.Test.Domain.Interfaces.Service;
using Project.Test.Domain.Service;
using Project.Test.Infra.Data.Context;
using Project.Test.Infra.Data.Repository;

namespace Project.Test.CrossCutting.Ioc
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<TestContext>();

            services.AddScoped(typeof(IBaseAppService<>), typeof(BaseAppService<,,>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped(typeof(ICarroAppService), typeof(CarroAppService));
            services.AddScoped(typeof(ICarroService), typeof(CarroService));
            services.AddScoped(typeof(ICarroRepository), typeof(CarroRepository));

            services.AddScoped(typeof(IManobristaAppService), typeof(ManobristaAppService));
            services.AddScoped(typeof(IManobristaService), typeof(ManobristaService));
            services.AddScoped(typeof(IManobristaRepository), typeof(ManobristaRepository));

            services.AddScoped(typeof(IManobraAppService), typeof(ManobraAppService));
            services.AddScoped(typeof(IManobraService), typeof(ManobraService));
            services.AddScoped(typeof(IManobraRepository), typeof(ManobraRepository));
        }
    }
}