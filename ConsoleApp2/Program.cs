using ConsoleApp2.Service;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using System.IO;
using Topshelf;

namespace ConsoleApp2
{
    class Program
    {

        //public static void Main(string[] args)
        //{
       //     var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
       //     var pathToContentRoot = Path.GetDirectoryName(pathToExe);

       //     var host = WebHost.CreateDefaultBuilder(args)
       //.UseContentRoot(pathToContentRoot)
       //.UseStartup<Startup>()
       //.Build();
            
           // CreateWebHostBuilder(args).Build().Run();
        //
        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HostFactory.Run(x =>
            {
                x.Service<FeedFileProcessor>(service =>
                {
                    service.ConstructUsing(s => new FeedFileProcessor());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                // Service log on as
                x.RunAsLocalSystem()
                  .StartAutomatically()
                  .EnableServiceRecovery(rc => rc.RestartService(5));

                x.SetServiceName("FeedFileProcessorService");
                x.SetDisplayName("FeedFileProcessor");
                x.SetDescription("Process the files , decryptes and calls the API to push to kafka");
            });
        }
    }
}
