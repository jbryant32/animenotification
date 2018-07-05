using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimeAratoBackend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using AnimeAratoBackend.Services;

namespace AnimeAratoBackend
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
            var builder = new ConfigurationBuilder()
                .AddJsonFile(new StringBuilder().Append(Directory.GetCurrentDirectory()).Append("\\appsettings.json").ToString());
            var Configuration = builder.Build();
            services.AddAuthentication((options) =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            })
            .AddCookie((options) => {
                options.LoginPath = "/login";
                options.LogoutPath = "/login";
                options.AccessDeniedPath = "/accessdenied";
                options.Cookie.Expiration = TimeSpan.FromDays(10);

            });
            services.AddCors((options)=> {
                options.AddPolicy("CorsPolicy", (build) =>
                {
                    build.WithOrigins("http://apianimearato.azurewebsites.net/", "https://apianimearato.azurewebsites.net/","http://localhost:62203");
                });
            });
            services.AddDbContext<AODatabase>((options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
          
            services.AddScoped<UserManager>();
            services.AddScoped<IRepository, RepositoryADO>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
