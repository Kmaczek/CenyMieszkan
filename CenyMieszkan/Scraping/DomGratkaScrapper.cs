using System;
using CenyMieszkan.Models.FlatData;
using HtmlAgilityPack;

namespace CenyMieszkan.Scraping
{
    public class DomGratkaScrapper : Scraper
    {
        private string privateUrl = @"http://dom.gratka.pl/mieszkania-sprzedam/lista/,wroclaw,40,{0},on,li,s,zi.html";

        public DomGratkaScrapper()
        {
            ScrapingUrl = privateUrl;
        }

        public virtual string Name { get { return "DomGratka"; } }

        protected override HtmlNodeCollection GetOffers(HtmlDocument document)
        {
            return document.DocumentNode.SelectNodes(@"//*[@data-gtm='zajawka']");
        }

        protected override int GetPageCount(HtmlDocument document)
        {
            var sth = document.DocumentNode.SelectSingleNode(@"//*[@class='strona']");
            return int.Parse(sth.InnerText.Trim());
        }

        protected override FlatData ParseOffer(HtmlNode node)
        {
            var ogloszenieInfo = node.SelectSingleNode(@".//*[@class='ogloszenieInfo']");
            var data = new FlatData();

            try
            {
                data.Url = GetUrl(node);
                //data.Location = GetLocation(ogloszenieInfo);
                data.Rooms = GetRooms(ogloszenieInfo);
                data.TotalPrice = GetPrice(node);
                data.SquareMeters = GetSquareMeters(ogloszenieInfo);
                //data.Year = GetYear(ogloszenieInfo);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Skipped: {ogloszenieInfo?.InnerHtml ?? "No inner HTML"} \n" + e);
                return null;
            }

            return data;
        }

        private int GetYear(HtmlNode ogloszenieInfo)
        {
            var urlNode = ogloszenieInfo.SelectSingleNode(@".//div/p/span[3]");
            return int.Parse(urlNode.InnerText);
        }

        private decimal GetSquareMeters(HtmlNode ogloszenieInfo)
        {
            var urlNode = ogloszenieInfo.SelectSingleNode(@"(.//div/p/span)[last()]/b");
            return decimal.Parse(urlNode.InnerText);
        }

        private decimal GetPrice(HtmlNode node)
        {
            var urlNode = node.SelectSingleNode(@".//*[@class='detailedPrice']/p/b");
            return decimal.Parse(urlNode.InnerText);
        }

        private int GetRooms(HtmlNode ogloszenieInfo)
        {
            var urlNode = ogloszenieInfo.SelectSingleNode(@".//div/p/span[1]");
            return int.Parse(urlNode.InnerText);
        }

        private string GetLocation(HtmlNode node)
        {
            var locationNode = node.SelectSingleNode(@".//h2");
            return locationNode.InnerText;
        }

        private string GetUrl(HtmlNode node)
        {
            var urlNode = node.SelectSingleNode(@".//a");
            return "http://dom.gratka.pl" + urlNode.GetAttributeValue("href", "");
        }
    }
}
