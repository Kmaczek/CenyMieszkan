using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenyMieszkan.SelfHosted.Model
{
    public class FlatDataEntry
    {
        public DateTime Date { get; set; }
        public decimal AvgTotalValue { get; set; }
        public decimal PerMeter { get; set; }
    }
}
