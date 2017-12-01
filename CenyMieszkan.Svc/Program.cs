using System.ServiceProcess;

namespace CenyMieszkan.Svc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new CenyMieszkanService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
