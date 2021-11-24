using G1WRGM_HFT_2021221.Data;
using G1WRGM_HFT_2021221.Logic.Classes;
using G1WRGM_HFT_2021221.Logic.Interfaces;
using G1WRGM_HFT_2021221.Repository.Classes;
using G1WRGM_HFT_2021221.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Logic
            services.AddTransient<ICommentLogic, CommentLogic>();
            services.AddTransient<IVideoLogic, VideoLogic>();
            services.AddTransient<IYTContentCreatorLogic, YTContentCreatorLogic>();
            //Repo
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IVideoRepository, VideoRepository>();
            services.AddTransient<IYTContentCreatorRepository, YTContentCreatorRepository>();
            //DbContext
            services.AddTransient<YTDbContext, YTDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
