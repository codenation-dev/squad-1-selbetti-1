using CentralErros.Models;
using CentralErros.Services;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CentralErros
{
    public class StartupIdentityServer
    {
        public IWebHostEnvironment Enviroment { get; set; }

        public StartupIdentityServer(IWebHostEnvironment enviroment)
        {
            Enviroment = enviroment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CentralErrosContext>();
            services.AddScoped<IResourceOwnerPasswordValidator, PasswordValidatorService>();
            services.AddScoped<IProfileService, UserProfileService>();
            var builder = services.AddIdentityServer()
                .AddProfileService<UserProfileService>();

            if (Enviroment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("ambiente de produção precisa de chave real");
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseStaticFiles();
            //app.UseIdentityServer();
        }
    }
}
