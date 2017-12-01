using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using CenyMieszkan.Models.FlatData;
using HtmlAgilityPack;

namespace CenyMieszkan.Scraping
{
    public abstract class Scraper
    {
        public string ScrapingUrl { get; protected set; }

        public virtual string Name { get { return "Generic"; } }

        protected abstract FlatData ParseOffer(HtmlNode node);

        protected abstract HtmlNodeCollection GetOffers(HtmlDocument document);

        protected abstract int GetPageCount(HtmlDocument document);

        public IEnumerable<FlatData> Scrape()
        {
            if (string.IsNullOrEmpty(ScrapingUrl))
            {
                throw new ArgumentException("ScrapingUrl is not set");
            }

            var results = new List<FlatData>();
            var currentPage = 1;
            var pageContent = GetContent(String.Format(ScrapingUrl, currentPage));
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(pageContent);
            var pageCount = GetPageCount(document);
            results.AddRange(ScrapPage(document));

            for (int i = 2; i <= pageCount; i++)
            {
                var content = GetContent(String.Format(ScrapingUrl, i));
                document.LoadHtml(content);
                var batch = ScrapPage(document);
                results.AddRange(batch);
            }

            return results;
        }

        protected string GetContent(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = new UTF8Encoding();
                return client.DownloadString(new Uri(url));
            }
        }

        protected IEnumerable<FlatData> ScrapPage(HtmlDocument document)
        {
            var parsedOffers = new List<FlatData>();
            var offers = GetOffers(document);

            foreach (var offer in offers)
            {
                var parsedOffer = ParseOffer(offer);
                if (parsedOffer == null)
                {
                    continue;
                }
                parsedOffers.Add(parsedOffer);
            }

            return parsedOffers;
        }
    }
}
