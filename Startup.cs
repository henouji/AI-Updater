using AI_Updater.Repositories;
using AI_Updater.Repositories.Contracts;
using AI_Updater.Services;
using AI_Updater.Services.Contracts;
using AI_Updater.SqlModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace AI_Updater
{
    public class Startup
    {
        public IConfiguration Configuration { get;}
        public Startup(IConfiguration configuration) { 
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();

            services.AddOpenApiDocument();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HNJ",
                    Version = "v1"
                });
            });

            services.AddDbContext<AIContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SQL_SERVER"));
            });

            //Repositories
            services.AddTransient<IUserRepository, UserRepository>();

            //Services
            services.AddTransient<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseCors(x => { x.AllowAnyOrigin(); });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseOpenApi();
            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
