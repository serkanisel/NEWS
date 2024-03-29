﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WordStudy.WebApi.Interfaces;
using WordStudy.WebApi.Repository;
using WordStudy.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using WordStudy.WebApi.Helpers;
using WordStudy.WebApi.Data;
using AutoMapper;

namespace WordStudy.WebApi
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
            
            services.AddDbContext<EWSDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("EWSDbContext")));
            //services.AddDbContext<EWSDbContext>(x => x.UseSqlite(Configuration.GetConnectionString("SqLiteDB")));
            services.AddScoped<IUsrRepository, UsrRepository>();
            services.AddScoped<IWordRepository, WordRepository>();
            services.AddScoped<IWrdListRepository, WrdListRepository>();
            services.AddScoped<IWordOfListRepository, WordOfListRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IListsRepository, ListsRepository>();
            services.AddScoped<ISentencesRepository, SentencesRepository>();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling =
                                           Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddMvc();
            services.AddCors();
            services.AddAutoMapper();
            services.AddTransient<Seed>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                ValidateIssuer = false,
                ValidateAudience = false,
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //global error handling for web api.
                app.UseExceptionHandler(builder => {
                    builder.Run(async context => {

                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();

                        if (error !=null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
            }

            seeder.SeedWords();
            seeder.SeedUsers();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
