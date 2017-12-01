using CenyMieszkan.Models.FlatData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenyMieszkan.SelfHosted.Model
{
    public class RawDataModel
    {
        public string Provider { get; set; }

        public DateTime ScrapedDate { get; set; }

        public IEnumerable<FlatData> Flats { get; set; }
    }
}
