using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace SoftplanApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();

            // Swagger Generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Softplan API",
                    Description = "Desafio técnico - Softplan",
                    Contact = new OpenApiContact
                    {
                        Name = "Nathalia Delavi",
                        Email = "nath.delavi@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/nathalia-delavi-75116339"),
                    }
                });

                // XML de comentários
                var arquivoXml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var pastaXml = Path.Combine(AppContext.BaseDirectory, arquivoXml);

                // Habilitação dos comentários na versão 5+
                c.IncludeXmlComments(pastaXml, includeControllerXmlComments: true);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Ativando middlewares para uso do Swagger
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Softplan API");
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
