using System;

namespace CenyMieszkan.Models.FlatData
{
    public class OtoDomFlatData : FlatData
    {
        public decimal SquareMeters { get; set; }
        public decimal TotalPrice { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Rooms { get; set; }
        public string Url { get; set; }

        public bool IsPrivate { get; set; }
        public string Location { get; set; }
    }
}
