using System;
using Nancy.Hosting.Self;

namespace VueNancy.Backend.Bootstrap
{
    internal class Startup
    {
        static void Main(string[] args)
        {
            var bindUrl = new Uri("http://localhost:8081");
            var bootstrapper = new Bootstrapper();
            var configuration = new HostConfiguration()
            {
                UrlReservations =
                {
                    CreateAutomatically = true
                }
            };

            using var host = new NancyHost(bootstrapper, configuration, bindUrl);
            host.Start();

            Console.WriteLine("NancyFX Stand alone test application.");
            Console.WriteLine("Press enter to exit the application");
            Console.ReadLine();
        }
    }
}