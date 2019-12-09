using AutoMapper;
using CentralErros.Models;
using CentralErros.Services;
<<<<<<< HEAD
using IdentityServer4.Services;
using IdentityServer4.Validation;
=======
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
>>>>>>> bbc9b386731dca1d405fb56b77c278a6ed19ac5d
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
<<<<<<< HEAD
using Microsoft.Extensions.Hosting;
=======
using Microsoft.Extensions.Options;
using System;
>>>>>>> bbc9b386731dca1d405fb56b77c278a6ed19ac5d

namespace CentralErros
{
    public class Startup
    {
<<<<<<< HEAD
        public IConfiguration Configuration { get; }

       // public StartupIdentityServer IdentityServerStartup { get; }

        public Startup(IConfiguration configuration/*, IWebHostEnvironment environment*/)
        {
            Configuration = configuration;

            /*if (!environment.IsEnvironment("Testing"))
                IdentityServerStartup = new StartupIdentityServer(environment);*/
=======
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
>>>>>>> bbc9b386731dca1d405fb56b77c278a6ed19ac5d
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
<<<<<<< HEAD
=======
            services.AddTransient<UserService>();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

>>>>>>> bbc9b386731dca1d405fb56b77c278a6ed19ac5d
            services.AddMvcCore();
            services.AddDbContext<CentralErrosContext>();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILogService, LogService>();
<<<<<<< HEAD

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
=======
>>>>>>> bbc9b386731dca1d405fb56b77c278a6ed19ac5d
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
