using CenyMieszkan.Scraping;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CenyMieszkan.Api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            var domGratka = new DomGratkaScrapper();
            var domResult = domGratka.Scrape();
            //var avg = domResult.Sum(x => x.TotalPrice) / domResult.Count();
            //var count = domResult.Count();
            //var perMeter = domResult.Select(x => x.TotalPrice / x.SquareMeters);
            //perMeter.Average();

            var jResponse = JsonConvert.SerializeObject(domResult);

            return Request.CreateResponse(HttpStatusCode.OK, jResponse);
        }
    }
}
