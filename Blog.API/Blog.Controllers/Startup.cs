using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Models.DataBase;
using Blog.Repos;
using Blog.Repos.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Controllers
{
    public class Startup
    {
        public IConfiguration ApplicationSetup { get; }
        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment env)
        {
            // we injected appsetting file
            var builder = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            ApplicationSetup = builder.Build();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // get value from appsettings file
            string originHost = ApplicationSetup.GetSection("Settings:HostFromAllowCORS").Value;
            string jwtKey = ApplicationSetup.GetSection("Settings:JwtKey").Value;
            string jwtIssuer = ApplicationSetup.GetSection("Settings:JwtIssuer").Value;
            string blogDB = ApplicationSetup.GetSection("Settings:BlogDB").Value;

            // basic configuration to CORS            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                builder =>
                {
                    builder.WithOrigins(originHost)
                                .AllowAnyHeader()
                                .AllowAnyOrigin()
                                .AllowAnyMethod();
                });
            });
            // jwt configuration
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtIssuer,
                        ValidAudience = jwtIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    };
                });

            services.AddMvc();
            services.AddOptions();
            services.AddSwaggerGen();
            services.AddControllers();
            services.Configure<SetUpModel>(ApplicationSetup.GetSection("Settings"));
            // connection string
            services.AddDbContext<BlogBDContext>(optionsAction: option => option.UseSqlServer(blogDB));
            // injected dependences
            services.AddScoped(serviceType: typeof(IUnitOfWork), implementationType: typeof(UnitofWork));
            services.AddScoped(serviceType: typeof(IRepository<>), implementationType: typeof(GenericRepository<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API V1.0.0");
                c.RoutePrefix = string.Empty;
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            // here asociate the policy that was created to CORS
            app.UseCors("AllowOrigin");
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
