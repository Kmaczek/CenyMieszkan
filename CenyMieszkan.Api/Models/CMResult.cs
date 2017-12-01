using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CenyMieszkan.Api.Models
{
    public class CMResult
    {
        public IEnumerable<DateTime> Dates { get; set; }
        public IEnumerable<decimal> Values { get; set; }
    }
}