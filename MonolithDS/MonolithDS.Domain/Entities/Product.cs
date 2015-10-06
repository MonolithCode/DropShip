using System;

namespace MonolithDS.Domain.Entities
{
    public class Product
    {
        public Guid ItemId { get; set; }
        public string Asin { get; set; }
        public string Sku { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Price { get; set; }
        public string LastCheckedDate { get; set; }
        public string Rating { get; set; }
        public string Upc { get; set; }
        public string Isbn { get; set; }
        public string Model { get; set; }
        public string Mpn { get; set; }
        public string Brand { get; set; }
        public string Url { get; set; }
        public string OfferListingId { get; set; }
        public string OffersUrl { get; set; }
        public string OutOfStock { get; set; }
    }
}