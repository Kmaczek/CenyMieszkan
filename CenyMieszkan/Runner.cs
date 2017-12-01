using System;
using System.Collections.Generic;
using System.Linq;
using CenyMieszkan.Models.FlatData;
using CenyMieszkan.Scraping;

namespace CenyMieszkan
{
    public class Runner
    {
        private List<Scraper> scrapers = new List<Scraper>();
        public Runner()
        {
//            scrapers.Add(new OtoDomScrapper());
            scrapers.Add(new DomGratkaScrapper());
        }

        public void Run()
        {
            Console.WriteLine("Calculating...");
            var flats = new List<FlatData>();
            foreach (var scraper in scrapers)
            {
                flats.AddRange(scraper.Scrape());
            }
            var avg = flats.Sum(x => x.TotalPrice)/flats.Count;
            Console.WriteLine($"Avg Price: {avg}");
            Console.WriteLine($"Count: {flats.Count}");
            var perMeter = flats.Select(x => x.TotalPrice/x.SquareMeters);
            Console.WriteLine($"Avg per Meter: {perMeter.Average()}");
        }
    }
}
