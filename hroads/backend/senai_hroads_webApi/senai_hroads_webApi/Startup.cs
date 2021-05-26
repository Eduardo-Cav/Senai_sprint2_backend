
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai_hroads_webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "hroads.webApi", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                ;            });

            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    //ignora os loopings
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //ignora os valores nulos ao fazer junções nas consultas
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services
                //forma de autenticação 
                .AddAuthentication(options =>
                {

                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";

                })
                //parâmetros de validação token
                .AddJwtBearer("JwtBearer", options => {

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //quem está emitindo
                        ValidateIssuer = true,

                        //quem recebe
                        ValidateAudience = true,

                        //tempo de expiração
                        ValidateLifetime = true,

                        //como foi criptografado e chave
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-chave-autenticacao")),

                        //tempo que o token vai expirar
                        ClockSkew = TimeSpan.FromMinutes(30),

                        //nome do issuer
                        ValidIssuer = "hroads.webApi",

                        //nome do audience
                        ValidAudience = "hroads.webApi"
                    };
                });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "hroads.webApi");
                c.RoutePrefix = string.Empty;
            });

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
