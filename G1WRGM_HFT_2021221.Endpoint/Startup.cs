using G1WRGM_HFT_2021221.Data;
using G1WRGM_HFT_2021221.Endpoint.Services;
using G1WRGM_HFT_2021221.Logic.Classes;
using G1WRGM_HFT_2021221.Logic.Interfaces;
using G1WRGM_HFT_2021221.Repository.Classes;
using G1WRGM_HFT_2021221.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Logic
            services.AddTransient<ICommentLogic, CommentLogic>();
            services.AddTransient<IVideoLogic, VideoLogic>();
            services.AddTransient<IYTContentCreatorLogic, YTContentCreatorLogic>();
            //Repo
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IVideoRepository, VideoRepository>();
            services.AddTransient<IYTContentCreatorRepository, YTContentCreatorRepository>();
            //DbContext
            //services.AddSingleton<DbContext, YTDbContext>();
            services.AddTransient<YTDbContext, YTDbContext>(); //<DbContext, YTDbContext> ha hiba lesz

            services.AddSignalR();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "G1WRGM_HFT_2021221.Endpoint", Version = "v1" });
            });
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "G1WRGM_HFT_2021221.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:61748"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
