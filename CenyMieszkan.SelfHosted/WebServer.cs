using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenyMieszkan.SelfHosted
{
    public class WebServer
    {
        private IDisposable _webApp;
        public void Start()
        {
            _webApp = WebApp.Start<Startup>("http://localhost:55555");
        }

        public void Stop()
        {
            _webApp?.Dispose();
        }
    }
}
