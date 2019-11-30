using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Consultant.ViewModels;
using System.Threading.Tasks;
using Windows.Storage;

namespace Sales.Client
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static void Init()
        {
            StorageFolder LocalFolder = ApplicationData.Current.LocalFolder;
            var configFile = ExtractResource("Sales.Client.appsettings.json", LocalFolder.Path);

            var host = new HostBuilder()
                        .ConfigureHostConfiguration(c =>
                        {
                            // Tell the host configuration where to file the file (this is required for Xamarin apps)
                            c.AddCommandLine(new string[] { $"ContentRoot={LocalFolder.Path}" });

                            //read in the configuration file!
                            c.AddJsonFile(configFile);
                        })
                        .ConfigureServices((c, x) =>
                        {
                            // Configure our local services and access the host configuration
                            ConfigureServices(c, x);
                        }).
                        ConfigureLogging(l => l.AddConsole(o =>
                        {
                            //setup a console logger and disable colors since they don't have any colors in VS
                            o.DisableColors = true;
                        }))
                        .Build();

            //Save our service provider so we can use it later.
            ServiceProvider = host.Services;
        }

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            //ViewModels
            services.AddTransient<ChartsViewModel>();
            services.AddTransient<MainPageViewModel>();
        }

        static string ExtractResource(string filename, string location)
        {
            var a = Assembly.GetExecutingAssembly();
            
            using (var resFilestream = a.GetManifestResourceStream(filename))
            {
                if (resFilestream != null)
                {
                    var full = Path.Combine(location, filename);

                    using (var stream = File.Create(full))
                    {
                        resFilestream.CopyTo(stream);
                    }
                }
            }
            return Path.Combine(location, filename);
        }
    }
}
