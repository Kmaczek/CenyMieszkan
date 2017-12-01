using CenyMieszkan.Scraping;
using CenyMieszkan.SelfHosted.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CenyMieszkan.SelfHosted
{
    public class CMJob
    {
        private List<Scraper> scrapers = new List<Scraper>()
        {
            new OtoDomScrapper(),
            new DomGratkaScrapper()
        };
        public CMJob()
        {
            var timer = new Timer(
                StartScraping, 
                new object(), 
                new TimeSpan(hours: 0, minutes: 0, seconds: 5).Milliseconds, 
                new TimeSpan(hours: 0, minutes: 0, seconds: 20).Milliseconds
                //new TimeSpan(hours: 0, minutes: 10, seconds: 0).Milliseconds,
                //new TimeSpan(hours: 24, minutes: 0, seconds: 0).Milliseconds
                );
        }

        private void StartScraping(object state)
        {
            var scrapedData = new List<RawDataModel>();
            foreach (var scraper in scrapers)
            {
                var data = scraper.Scrape();
                var result = new RawDataModel()
                {
                    Provider = scraper.Name,
                    ScrapedDate = DateTime.Now,
                    Flats = data
                };
                scrapedData.Add(result);
            }


        }

        private bool WasJobExecutedToday()
        {

            return false;
        }
    }
}
