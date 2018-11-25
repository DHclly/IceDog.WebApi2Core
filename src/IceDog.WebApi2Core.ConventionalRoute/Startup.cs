using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Microsoft.Extensions.PlatformAbstractions;
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

            services.AddDbContext<ProductContext>(opt =>opt.UseInMemoryDatabase("ProductInventory"));//inventory 清单、库存
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

                //给swagger生成器设置项目生成的xml注释文档的路径
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                //var basePath = AppContext.BaseDirectory;
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                var xmlPath = Path.Combine(basePath, xmlFile);
                c.IncludeXmlComments(xmlPath);//可以调用多个

                xmlFile = $"{typeof(ProductContext).Assembly.GetName().Name}.xml";
                xmlPath = Path.Combine(basePath, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.DescribeAllEnumsAsStrings();//描述枚举值为字面量，而不是数值
                c.DescribeStringEnumsInCamelCase();//所有枚举变量用camelCase
                c.DescribeAllParametersInCamelCase();//所有参数变量用camelCase
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                //options.SuppressConsumesConstraintForFormFileParameters = true;//禁止对表单文件参数的默认行为
                //options.SuppressInferBindingSourcesForParameters = true;//禁用默认推理规则,禁止推断绑定参数源
                //options.SuppressModelStateInvalidFilter = true;//禁用模型状态无效过滤器，如果操作可从模型验证错误中恢复，禁用默认行为是有用的。
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
