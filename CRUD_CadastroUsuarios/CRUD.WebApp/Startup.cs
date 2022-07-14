using CRUD.Dominio;
using CRUD.Infra;
using FluentValidation;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.OpenApi.Models;

namespace CRUD.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MapeamentoDasTabelas.Mapear();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(services => {
            //    services.AddPolicy("CorsPolicy", build => build
            //    .AllowAnyOrigin()
            //    .AllowAnyHeader()
            //    .AllowAnyMethod());
            //});

            services.AddCors();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioComLinqToDb>();
            services.AddScoped<IValidator<Usuario>, ValidarUsuario>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD.WebApp", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aplicação CRUD Swagger UI"));
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = new FileExtensionContentTypeProvider
                {
                    Mappings = { [".properties"] = "application/x-msdownload"}
                }
            });

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
