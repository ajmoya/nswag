using Api.OperationProcessor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Registramos el servicio OpenAPI 3.0 con dos documentos
            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "doc";
                document.PostProcess = apiDocument =>
                {
                    apiDocument.Info.Title = "Doc API IyA";
                    apiDocument.Info.Description = "Documentación y ayuda de la API Incidencias y Avisos";
                    apiDocument.Info.Version = "1.0.0";
                };
            });

            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "read";
                document.PostProcess = apiDocument =>
                {
                    apiDocument.Info.Title = "Doc API IyA [con limitaciones]";
                    apiDocument.Info.Description = "Documentación y ayuda de la API Incidencias y Avisos";
                    apiDocument.Info.Version = "1.0.0";
                };

                // Se inserta como la 1ª operación, para que el schema del controller a ocultar en la doc no aparezca en la definición del json
                document.OperationProcessors.Insert(0, new VisibilidadLimitadaDocs());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            
            // Registramos el middleware del generador OpenAPI 3.0
            app.UseOpenApi(options =>
            {
                options.DocumentName = "doc";
                options.Path = "/doc/openapi.json";
            });
            app.UseOpenApi(options =>
            {
                options.DocumentName = "read";
                options.Path = "/read/openapi.json";
            });

            // Registramos el middleware de la UI Swagger/OpenAPI 3.0
            app.UseSwaggerUi3(options =>
            {
                options.Path = "/doc";
                options.DocumentPath = "/doc/openapi.json";
                options.DocumentTitle = "Doc API IyA";
            });

            app.UseSwaggerUi3(options =>
            {
                options.Path = "/read";
                options.DocumentPath = "/read/openapi.json";
                options.DocumentTitle = "Doc API IyA v2";
            });


            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
