using Microsoft.Owin.Hosting;
using System;
using Topshelf;

namespace CenyMieszkan.SelfHosted
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<WebServer>(s =>
                {
                    s.ConstructUsing(name => new WebServer());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("Flats prices scrapping svc");
                x.SetDisplayName("Ceny Mieszkan");
                x.SetServiceName("CenyMieszkan");
            });
        }
    }
}
