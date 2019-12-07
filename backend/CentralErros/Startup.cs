using AutoMapper;
using CentralErros.Models;
using CentralErros.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CentralErros
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public StartupIdentityServer IdentityServerStartup { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;

            if (!environment.IsEnvironment("Testing"))
                IdentityServerStartup = new StartupIdentityServer(environment);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<CentralErrosContext>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUserService, UserService>();

            if (IdentityServerStartup != null)
                IdentityServerStartup.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            if (IdentityServerStartup != null)
                IdentityServerStartup.Configure(app, env);

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
