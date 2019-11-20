using System.IO.Compression;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Test.CrossCutting.Ioc;
using Project.Test.Infra.Data.Context;
using Swashbuckle.AspNetCore.Swagger;

namespace Project.Test.Api
{
    public class Startup
    {
        private const string CorsPolicy = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestContext>(x => x.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            services.AddControllers();
            Injector.RegisterServices(services);

            #region AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();

            #endregion

            #region Test Compressão

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
            #endregion

            #region Cors
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy, builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });

            #endregion

            #region Swagger 

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", GetBasicSwaggerInfo());

            //    string caminhoAplicacao =
            //      PlatformServices.Default.Application.ApplicationBasePath;
            //    string nomeAplicacao =
            //        PlatformServices.Default.Application.ApplicationName;
            //    string caminhoXmlDoc =
            //        Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

            //    c.IncludeXmlComments(caminhoXmlDoc);
            //});


            #endregion
        }

        private Info GetBasicSwaggerInfo()
        {
            return new Info
            {
                Title = "Teste Project",
                Version = "v1",
                Description = "Documentação da API criada para teste",
                Contact = new Contact
                {
                    Name = "Anselmo de Oliveira Coelho Jr",
                    Email = "anselmo.trab@gmail.com"
                }
            };
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(CorsPolicy);
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSwagger();
            //app.UseSwaggerUI();
        }
    }
}
