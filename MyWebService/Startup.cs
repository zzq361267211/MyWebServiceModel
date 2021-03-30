using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebServiceModel
{
    public class Startup
    {
        public static ILoggerRepository LogRepository { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            LogRepository = LogManager.CreateRepository("NETCoreReposity");
            XmlConfigurator.Configure(LogRepository,new FileInfo(fileName:"log4net.config"));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //该方法在运行时被调用，使用此方法将用来把 服务 添加到容器当中
        public void ConfigureServices(IServiceCollection services)
        {
            #region Core原生自带
            services.AddControllersWithViews();
            #endregion

            #region 注册Swagger
            //注册swagger服务  NuGet下载：Swashbuckle.AspNetCore   详情参考：https://blog.csdn.net/biubiiu/article/details/100976919
            services.AddSwaggerGen(m =>
            {
                m.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MyWebServiceModel",
                    Version = "v1"
                });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //该方法在运行时被调用，使用此方法将用来配置需组装的 HTTP请求管道  （Aop管道处理）
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            


            #region Core原生自带部分
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            //强制使用https，把所有的HTTP请求转换为HTTPS（出于安全性的考虑）（疑问点：http与https的区别？）  ,相关文档参看 https://www.jianshu.com/p/f70e8acba934
            app.UseHttpsRedirection();

            //配置服务中 静态文件 根路径，cshtml里面 (.js||.image||.css)  默认为 wwwroot ，可单独配置         相关文档参看 https://blog.csdn.net/qq_37665834/article/details/82878959
            app.UseStaticFiles();
            //默认如上，自定义根目录路径如下注释部分  D:/MyStaticFiles/StaticFiles    
            //在cshtml中使用路径: <img src="~/StaticFiles/images/banner1.svg" alt="pic"/>
            //可访问D盘的MyStaticFiles文件夹下的images文件夹下的banner1.svg：
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider("D:/MyStaticFiles"),
            //    RequestPath = "/StaticFiles"
            //});



            //app.UseMvcWithDefaultRoute();
            app.UseRouting();

            app.UseAuthorization();

            //启动项目时默认的路径
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion


            //启用中间件服务生成Swagger作为JSON终结点 
            //注意点
            //① 与下文中UseEndPoint()的位置关系，处于前面的生效
            //② 与API接口的 [Route("")] 的关系，在页面会报错：No operations defined in spec!
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebService API V1");
               // c.RoutePrefix = string.Empty;//如果设置更目录为swagger,将此值置空，可在 http://localhost:<port>/ 找到 Swagger UI

                c.RoutePrefix = "swagger";//决定访问Swagger UI的路径，可在 http://localhost:<port>/swagger 找到 Swagger UI　　
            });


            //Model转换配置，直接as 转换，省去挨个儿赋值
            ModelMap.ModelMapInit();


           
        }
    }
}
