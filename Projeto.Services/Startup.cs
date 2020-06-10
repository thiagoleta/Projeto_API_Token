using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Projeto.Data.Context;
using Projeto.Data.Contracts;
using Projeto.Data.Repository;

namespace Projeto.Services
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region AutoMapper
            services.AddAutoMapper(typeof(Startup));
            #endregion

            #region EntityFramework

            services.AddDbContext<DataColetrans>
                 (options => options.UseSqlServer(Configuration.GetConnectionString("Coletrans")));

            #endregion

            #region Swagger

            services.AddSwaggerGen(
               c =>
               {
                   c.SwaggerDoc("v1", new OpenApiInfo
                   {
                       Title = "Sistema Coleta de Lixo",
                       Description = "API REST para integração com serviços de Coleta",
                       Version = "v1",
                       Contact = new OpenApiContact
                       {
                           Name = "Thiago Leta Soluções",
                           Url = new Uri("http://www.cotiinformatica.com.br/"),
                           Email = "thiagoleta2013@gmail.com.br"
                       }
                   });
               }
               );

            #endregion



            #region Injeção de Dependência

            services.AddTransient<IMotoristaRepository, MotoristaRepository>();
            services.AddTransient<IRotaRepository, RotaRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto API");
            });

            #endregion


            app.UseMvc();
        }
    }
}
