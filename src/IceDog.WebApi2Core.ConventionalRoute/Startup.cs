using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceDog.WebApi2Core.DataAccess;
using IceDog.WebApi2Core.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace IceDog.WebApi2Core.ConventionalRoute
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
            services.AddScoped<ProductsRepository>();
            services.AddScoped<PetsRepository>();

            services.AddDbContext<ProductContext>(opt =>opt.UseInMemoryDatabase("ProductInventory"));
            services.AddDbContext<PetContext>(opt =>opt.UseInMemoryDatabase("PetInventory"));

            //用于可以使用[ApiController]特性
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "ASP.NET Core 2.1+ Web API2",
                    Version = "v1"
                });
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressConsumesConstraintForFormFileParameters = true;
                options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //HSTS（HTTP Strict Transport Security）国际互联网工程组织IETF正在推行一种
                //新的Web安全协议HSTS的作用是强制客户端（如浏览器）使用HTTPS与服务器创建连接。
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();
        }
    }
}
