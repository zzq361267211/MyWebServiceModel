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
            CreateHostBuilder(args).Build().Run();//CreateWebHostBuilder������Kestrel������������������������--ת��--��Ӧ�ͻ�������(�����Ͳ���ҪIIS�����������ת������Ӧ�ͻ���������,IIS��ֻ��������������)
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureLogging((context, loggingbuilder) =>
             {
                 //�÷�����Ҫ����Microsoft.Extensions.Logging���ƿռ�

                 loggingbuilder.AddFilter("System", LogLevel.Warning); //���˵�ϵͳĬ�ϵ�һЩ��־
                 loggingbuilder.AddFilter("Microsoft", LogLevel.Warning);//���˵�ϵͳĬ�ϵ�һЩ��־

                 //���Log4Net

                 //var path = Directory.GetCurrentDirectory() + "\\log4net.config"; 
                 //������������ʾlog4net.config�������ļ�����Ӧ�ó����Ŀ¼�£�Ҳ����ָ�������ļ���·��
                 loggingbuilder.AddEventLog();
             })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
