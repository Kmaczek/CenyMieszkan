using CenyMieszkan.Models.FlatData;
using HtmlAgilityPack;

namespace CenyMieszkan.Scraping
{
    public class OtoDomScrapper : Scraper
    {
        private string allUrl = @"https://www.otodom.pl/sprzedaz/mieszkanie/wroclaw/?search%5Bdist%5D=0"; // will not work probably
        private string privateUrl = "https://www.otodom.pl/sprzedaz/mieszkanie/wroclaw/?search%5Bdescription%5D=1&search%5Bprivate_business%5D=private&search%5Bdist%5D=0&nrAdsPerPage=72&page={0}";

        public OtoDomScrapper()
        {
            ScrapingUrl = privateUrl;
        }

        public override string Name { get { return "OtoDom"; } }

        protected override int GetPageCount(HtmlDocument document)
        {
            var sth = document.DocumentNode.SelectSingleNode(@"//*[@class='current']");
            return int.Parse(sth.InnerText.Trim());
        }

        protected override HtmlNodeCollection GetOffers(HtmlDocument document)
        {
            return document.DocumentNode.SelectNodes(@"//*[@id='body-container']/div/div/div[2]/div/article");
        }

        protected override FlatData ParseOffer(HtmlNode node)
        {
            var detailsNode = node.SelectSingleNode(@".//*[@class='offer-item-details']");
            var bottomDetails = node.SelectSingleNode(@".//*[@class='offer-item-details-bottom']");
            if (IsPromo(detailsNode))
            {
                return null;
            }
            
            var data = new FlatData();
            data.Url = GetUrl(detailsNode);
            data.Rooms = GetRooms(detailsNode);
            data.TotalPrice = GetPrice(detailsNode);
            data.SquareMeters = GetSquareMeters(detailsNode);
            //data.Location = GetLocation(detailsNode);
            return data;
        }

        private bool IsPromo(HtmlNode node)
        {
            var urlNode = node.SelectSingleNode(@".//header/h3/a");
            var str = urlNode.GetAttributeValue("data-featured-tracking", "");
            return "promo_top_ads".Equals(str) || "promo_vip".Equals(str);
        }

        private string GetLocation(HtmlNode node)
        {
            var urlNode = node.SelectSingleNode(@".//header/p");
            return urlNode.InnerText;
        }

        private decimal GetSquareMeters(HtmlNode node)
        {
            var urlNode = node.SelectSingleNode(@".//*[@class='hidden-xs offer-item-area']");
            var str = urlNode.InnerText.Trim().Split(' ');
            return decimal.Parse(str[0]);
        }

        private decimal GetPrice(HtmlNode node)
        {
            var urlNode = node.SelectSingleNode(@".//*[@class='offer-item-price']");
            var str = urlNode.InnerText.Trim().Split(' ');
            return decimal.Parse(str[0] + str[1]);
        }

        private int GetRooms(HtmlNode node)
        {
            var urlNode = node.SelectSingleNode(@".//*[@class='offer-item-rooms hidden-xs']");
            var str = urlNode.InnerText.Trim().Split(' ')[0];
            return int.Parse(str);
        }

        private string GetUrl(HtmlNode node)
        {
            var urlNode = node.SelectSingleNode(@".//header/h3/a");
            return urlNode.GetAttributeValue("href", "");
        }
    }
}
