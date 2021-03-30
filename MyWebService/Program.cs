using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;

namespace MyWebServiceModel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();//CreateWebHostBuilder启动了Kestrel服务器，这个服务器负责监听--转发--响应客户端请求(这样就不需要IIS来负责监听，转发，响应客户端请求了,IIS就只做反向代理就行了)
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureLogging((context, loggingbuilder) =>
             {
                 //该方法需要引入Microsoft.Extensions.Logging名称空间

                 loggingbuilder.AddFilter("System", LogLevel.Warning); //过滤掉系统默认的一些日志
                 loggingbuilder.AddFilter("Microsoft", LogLevel.Warning);//过滤掉系统默认的一些日志

                 //添加Log4Net

                 //var path = Directory.GetCurrentDirectory() + "\\log4net.config"; 
                 //不带参数：表示log4net.config的配置文件就在应用程序根目录下，也可以指定配置文件的路径
                 loggingbuilder.AddEventLog();
             })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
