using AutoMapper;
using CentralErros.Models;
using CentralErros.Services;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CentralErros
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

       // public StartupIdentityServer IdentityServerStartup { get; }

        public Startup(IConfiguration configuration/*, IWebHostEnvironment environment*/)
        {
            Configuration = configuration;

            /*if (!environment.IsEnvironment("Testing"))
                IdentityServerStartup = new StartupIdentityServer(environment);*/
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
            services.AddDbContext<CentralErrosContext>();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILogService, LogService>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            //services.AddScoped<IResourceOwnerPasswordValidator, PasswordValidatorService>();
            //services.AddScoped<IProfileService, UserProfileService>();

            /* if (IdentityServerStartup != null)
                 IdentityServerStartup.ConfigureServices(services);*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowMyOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            /*if (IdentityServerStartup != null)
                IdentityServerStartup.Configure(app, env);*/

            //app.UseAuthentication();
            //app.UseMvcWithDefaultRoute();
        }
    }
}
