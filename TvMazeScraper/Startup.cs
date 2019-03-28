using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using Swashbuckle.AspNetCore.Swagger;
using TvMazeScraper.Constants;
using TvMazeScraper.Data;
using TvMazeScraper.Services;

namespace TvMazeScraper
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.Configure<TvMazeEndpointSettings>(Configuration.GetSection("TvMazeEndpointSettings"));


            services.AddDbContext<MazeDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITvMazeScraperService, TvMazeScraperService>();

            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<IShowDataService, ShowDataService>();

            var rateLimitTvMazePolicy = Policy.HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10)
                });


            //register tvMazeScraperService            
            services.AddHttpClient(TvMazeConstants.TvMazeShowsApiEndpoint, client =>
            {
                client.BaseAddress = new Uri(Configuration.GetValue<string>("TvMazeEndpointSettings:Shows"));
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            }).AddPolicyHandler(rateLimitTvMazePolicy);



            //register tvMazeScraperService            
            services.AddHttpClient(TvMazeConstants.TvMazeCastApiEndpoint, client =>
            {
                client.BaseAddress = new Uri(Configuration.GetValue<string>("TvMazeEndpointSettings:Cast"));
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            }).AddPolicyHandler(rateLimitTvMazePolicy);

            //register swagger generator
            services.AddSwaggerGen(c=>c.SwaggerDoc("v1", new Info
            {
                Title = "Tv Maze Scraper API",
                Version = "v1"
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
