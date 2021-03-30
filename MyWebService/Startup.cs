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
        //�÷���������ʱ�����ã�ʹ�ô˷����������� ���� ��ӵ���������
        public void ConfigureServices(IServiceCollection services)
        {
            #region Coreԭ���Դ�
            services.AddControllersWithViews();
            #endregion

            #region ע��Swagger
            //ע��swagger����  NuGet���أ�Swashbuckle.AspNetCore   ����ο���https://blog.csdn.net/biubiiu/article/details/100976919
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
        //�÷���������ʱ�����ã�ʹ�ô˷�����������������װ�� HTTP����ܵ�  ��Aop�ܵ�����
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            


            #region Coreԭ���Դ�����
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


            //ǿ��ʹ��https�������е�HTTP����ת��ΪHTTPS�����ڰ�ȫ�ԵĿ��ǣ������ʵ㣺http��https�����𣿣�  ,����ĵ��ο� https://www.jianshu.com/p/f70e8acba934
            app.UseHttpsRedirection();

            //���÷����� ��̬�ļ� ��·����cshtml���� (.js||.image||.css)  Ĭ��Ϊ wwwroot ���ɵ�������         ����ĵ��ο� https://blog.csdn.net/qq_37665834/article/details/82878959
            app.UseStaticFiles();
            //Ĭ�����ϣ��Զ����Ŀ¼·������ע�Ͳ���  D:/MyStaticFiles/StaticFiles    
            //��cshtml��ʹ��·��: <img src="~/StaticFiles/images/banner1.svg" alt="pic"/>
            //�ɷ���D�̵�MyStaticFiles�ļ����µ�images�ļ����µ�banner1.svg��
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider("D:/MyStaticFiles"),
            //    RequestPath = "/StaticFiles"
            //});



            //app.UseMvcWithDefaultRoute();
            app.UseRouting();

            app.UseAuthorization();

            //������ĿʱĬ�ϵ�·��
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion


            //�����м����������Swagger��ΪJSON�ս�� 
            //ע���
            //�� ��������UseEndPoint()��λ�ù�ϵ������ǰ�����Ч
            //�� ��API�ӿڵ� [Route("")] �Ĺ�ϵ����ҳ��ᱨ��No operations defined in spec!
            app.UseSwagger();
            //�����м�������swagger-ui��ָ��Swagger JSON�ս��
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebService API V1");
               // c.RoutePrefix = string.Empty;//������ø�Ŀ¼Ϊswagger,����ֵ�ÿգ����� http://localhost:<port>/ �ҵ� Swagger UI

                c.RoutePrefix = "swagger";//��������Swagger UI��·�������� http://localhost:<port>/swagger �ҵ� Swagger UI����
            });


            //Modelת�����ã�ֱ��as ת����ʡȥ��������ֵ
            ModelMap.ModelMapInit();


           
        }
    }
}
