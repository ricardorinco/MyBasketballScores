using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyBasketballScores.Domain.Interfaces.Repositories;
using MyBasketballScores.Domain.Interfaces.Services;
using MyBasketballScores.Domain.Services;
using MyBasketballScores.Infra.Data.Persistences.DataContext;
using MyBasketballScores.Infra.Data.Persistences.Repositories;
using MyBasketballScores.Infra.Data.Transactions;
using System;

namespace MyBasketballScores.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();

            AddSwagger(services);

            AddDependencyInjection(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyBasketballScores - v1.0");
            });

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<MyBasketballScoresContext, MyBasketballScoresContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<IScoreService, ScoreService>();
            services.AddScoped<ISeasonReportService, SeasonReportService>();

            // Repositories
            services.AddScoped<IScoreRepository, ScoreRepository>();
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "My Basketball Scores",
                        Version = "1.0",
                        Description = "Acompanhamento de pontos de jogos de basquete .",
                        Contact = new OpenApiContact
                        {
                            Name = "Ricardo Rinco",
                            Url = new Uri("https://github.com/ricardorinco/MyBasketballScores/")
                        }
                    }
                );
            });
        }
    }
}
