
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using PokeLexApi.Models;
using PokeLexApi.Interfaces;
using PokeLexApi.Data;
using PokeLexApi.Services;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace PokeLexApi
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
            services.Configure<Settings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });

            services.AddTransient<IPokemonRepository, PokemonRepository>();
            services.AddTransient<IPokemonMoveRepository, PokemonMoveRepository>();
            services.AddTransient<IPokemonTypeRepository, PokemonTypeRepository>();
            services.AddSingleton<IImageRepository, ImageRepository>();
            services.AddSingleton<ILoadDataService, LoadDataService>();

            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PokeLexApi", Version = "v1" });
            });

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PokeLexApi v1"));
            }
            else
            {
                app.UseSpaStaticFiles();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
           {
               spa.Options.SourcePath = "Frontend";
               if (env.IsDevelopment())
               {
                   spa.UseAngularCliServer(npmScript: "start");
               }
           });
        }
    }
}
