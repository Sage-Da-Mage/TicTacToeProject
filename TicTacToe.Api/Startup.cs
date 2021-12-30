using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Api.Middleware;
using TicTacToe.Repository;
using TicTacToe.Repository.Repositories;
using TicTacToe.Repository.Repositories.Interfaces;
using TicTacToe.Service.Interfaces;
using TicTacToe.Service.Services;

namespace TicTacToe.Api
{
    /// <summary>
    /// The Startup Class, where we configure Dependncy Injection, Swagger and middleware/exceptions.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The constructor that initializes the configuration
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure Dependency Injection so that the layers can all interact as needed
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureDependencyInjection(IServiceCollection services)
        {
            // Add services as services
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPlayerService, PlayerService>();

            // Add Repositories as services
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
        }


        /// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Swagger generator to create JSON documentation content
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tic Tac Toe API", Version = "v1" });

                var apiPath = Path.Combine(System.AppContext.BaseDirectory, "TicTacToe.Api.xml");
                var modelsPath = Path.Combine(System.AppContext.BaseDirectory, "TicTacToe.Models.xml");
                c.IncludeXmlComments(apiPath);
                c.IncludeXmlComments(modelsPath);

            });


            // Setup our database using the ApplicationDbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql( // Connect to the postgres database
                    Configuration.GetConnectionString("DefaultConnection"),
                    b =>
                    {
                        // Configure what project we want to store our Code-First Migrations in
                        b.MigrationsAssembly("TicTacToe.Repository");
                    })
                );

            services.AddControllers();

            ConfigureDependencyInjection(services);

        }

        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            // Make Swagger JSON file available
            app.UseSwagger();

            // Make Swagger UI available at /swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tic Tac Toe API V1");
            });


            // Global error handler 
            app.UseMiddleware<GlobalExceptionHandler>();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
