using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Zula.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    var allowedHosts = Configuration.GetSection("AllowedHosts").Get<string>().Split(";");
                    builder
                    .SetIsOriginAllowed(origin => {
                        return allowedHosts.Contains(origin);
                    })
                    .AllowAnyMethod();
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Zula.API", Version = "v1" });
            });
            // handlers
            services.AddScoped<Handlers.IRecipesHandler, Handlers.RecipesHandler>();
            // services
            services.AddScoped<Interfaces.ExternalApis.IRecipesApi, Services.RecipesApi>();
            services.AddHttpClient<Interfaces.Services.IHttpClient, Services.HttpClientWrapper>();
            // databases
            services.AddScoped<Interfaces.Repositories.IRecipeRepository, EFCore.RecipeRepository>();
            services.AddScoped<Interfaces.Repositories.IUnitOfWork, EFCore.UnitOfWork>();
            ConfigureEFCore(services);
            // configurations
            services.Configure<AppSettings.ApiKeys>(Configuration.GetSection("ApiKeys"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zula.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureEFCore(IServiceCollection services)
        {
            //var sqlConfig = Configuration.GetSection("App:Sql").Get<AppSettings.SqlConfig>();
            //var connectionString = $"server={sqlConfig.Address};user={sqlConfig.Username};password={sqlConfig.Password};database={sqlConfig.DbName}";

            //ServerVersion serverVersion = new MySqlServerVersion(new System.Version(5, 5, 62));
            var connectionString = Configuration.GetConnectionString("hostinger");
            services.AddDbContext<EFCore.DBContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)) // <-- Use<MySql/Sql/InMemoryDb> diffrent nugets
                    .EnableSensitiveDataLogging() // <-- These two calls are optional but help
                    .EnableDetailedErrors()       // <-- with debugging (remove for production).
            );
        }
    }
}
