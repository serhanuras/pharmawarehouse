using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using PharmaWarehouse.Api.Modules.Cache;
using PharmaWarehouse.Api.Modules.Data;
using PharmaWarehouse.Api.Modules.Extensions;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace PharmaWarehouse.Api
{
    public class Startup
    {
        private const string ALLOWSPECIFICORIGINS = "AllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Enable Caching
            // In Memory Caching
            services.AddInMemoryCache(this.Configuration);

            /*
            Redis Chaching
            services.AddRedisCache(this.Configuration);
            */

            services.AddScoped<QueryFactory>(conf =>
            {
                var connection = new MySqlConnection(
                    this.Configuration.GetMySqlConnectionString());

                var compiler = new MySqlCompiler();

                return new QueryFactory(connection, compiler);
            });

            services.AddCors(options =>
            {
                options.AddPolicy(
                    ALLOWSPECIFICORIGINS,
                    builder => builder.WithOrigins("http://www.apirequest.io", "http://localhost:3000", "http://admin.ottobotest.com")
                        .AllowAnyHeader()
                        .WithOrigins("*").WithMethods("GET", "POST", "GET, POST, PUT, DELETE, OPTIONS")
                        .AllowAnyMethod());
            });

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",

                    Title = "Pharma Warehouse Web API",
                    Description = "This is a Web API for Pharma Warehouse Clients",
                    License = new OpenApiLicense()
                    {
                        Name = "MIT",
                    },
                    Contact = new OpenApiContact()
                    {
                        Name = "Info@Xinerji Ltd",
                        Email = "info@xinerji.com",
                        Url = new Uri("http://www.xinerji.com.tr"),
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });

            services.AddResponseCaching();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var serviceProvider = services.BuildServiceProvider();

            var unitOfWork = serviceProvider.GetService<IUnitOfWork>();
            var cacheStore = serviceProvider.GetService<ICacheStore>();

            services.AddServices(serviceProvider, unitOfWork, cacheStore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(config => { config.SwaggerEndpoint("/swagger/v1/swagger.json", "PharmaWarehouse API"); });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(ALLOWSPECIFICORIGINS);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
