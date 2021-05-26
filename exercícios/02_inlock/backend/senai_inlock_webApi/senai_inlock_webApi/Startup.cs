using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                //Define o tipo de autenticação do token
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                //define os parâmentros de validação do token
                .AddJwtBearer("JwtBearer", options =>
                {

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //validar quem está emitindo o token
                        ValidateIssuer = true,

                        //valdidar quem está recebendo
                        ValidateAudience = true,

                        //valida o tempo de expiração
                        ValidateLifetime = true,

                        //forma de criptografia e a chave de autenticação
                        //chave de assinatura que o emissor usa
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-autenticacao-ultra-secreta")),

                        //tempo que definimo o token ser validado
                        ClockSkew = TimeSpan.FromMinutes(30),

                        //nome do issuer, de onde está vindo
                        ValidIssuer = "inlock.webApi",

                        //nome do audience, de onde está vindo
                        ValidAudience = "inlock.webApi"
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

            app.UseRouting();

            //utiliza a autenticação (login)
            app.UseAuthentication();

            //utiliza a autorização (permissão)
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
