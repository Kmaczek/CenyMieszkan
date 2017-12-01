using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CenyMieszkan.Svc
{
    public class CenyMieszkanService : ServiceBase
    {
        public CenyMieszkanService()
        {
            this.ServiceName = "CenyMieszkan";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            var runner = new Runner();
            runner.Run();
        }
    }
}
