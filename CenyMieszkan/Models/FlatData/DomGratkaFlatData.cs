namespace CenyMieszkan.Models.FlatData
{
    public class DomGratkaFlatData: FlatData
    {
        public decimal SquareMeters { get; set; }
        public decimal TotalPrice { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Rooms { get; set; }
        public string Url { get; set; }

        public string Location { get; set; }
        public int Year { get; set; }
    }
}
