using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using IdentityServer4.AccessTokenValidation;

namespace AG
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
            IdentityModelEventSource.ShowPII = true;
            services.AddControllers();
            services.AddOcelot();

            //var identityServerConfig = new IdentityServerConfig();
            //Configuration.Bind("IdentityServerConfig", identityServerConfig);
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("APIService8001", options =>
                {
                    options.Authority = $"http://localhost:15000";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "identityAPIService8001";
                    options.SupportedTokens = SupportedTokens.Both;
                });
            //.AddIdentityServerAuthentication(options =>
            //{
            //    options.RequireHttpsMetadata = false;
            //    options.Authority = $"http://localhost:15000";
            //    options.ApiName = "identityAPIService";
            //}
            //);



            //services
            //    .AddAuthentication("Bearer")
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.Authority = "https://localhost:15001";
            //        options.RequireHttpsMetadata = false;
            //        options.ApiName = "api1";
            //    });

            //var authenticationProviderKey = "user";

            //var identityUrl = "http://localhost:15000";

            //services.AddAuthentication()
            //        .AddJwtBearer(authenticationProviderKey, x =>
            //        {
            //            x.Authority = identityUrl;
            //            x.RequireHttpsMetadata = false;
            //            //x.Configuration = new OpenIdConnectConfiguration();
            //            x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            //            {
            //                //ValidAudiences = new[] { "user" }
            //            };
            //        });

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(authenticationProviderKey, x =>
            //        {
            //            //x.RequireHttpsMetadata = false;
            //            //x.Authority = identityUrl;
            //            x.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateIssuerSigningKey = false,
            //                //IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("111")),
            //                ValidateIssuer = false,
            //                ValidateAudience = false,
            //                SignatureValidator = delegate (string token, TokenValidationParameters parameters)
            //                {
            //                    var jwt = new JwtSecurityToken(token);

            //                    return jwt;
            //                },

            //            };
            //        });

            ////var identityUrl = "http://localhost:50000/api/login";///Configuration.GetValue<string>("IdentityUrl");
            //var identityUrl = "http://localhost:9000/api/forest";
            //var authenticationProviderKey = "secretkey";
            ////…
            //services.AddAuthentication()
            //    .AddJwtBearer(authenticationProviderKey, x =>
            //    {
            //        x.Authority = identityUrl;
            //        x.RequireHttpsMetadata = false;
            //        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            //        {
            //            ValidAudiences = new[] { "user" }
            //        };
            //    });
            ////...


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseOcelot();



            //app.UseHttpsRedirection();

            //app.UseRouting();


            ////app.UseAuthorization();




            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
