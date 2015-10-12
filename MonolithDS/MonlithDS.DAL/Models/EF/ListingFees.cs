namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ListingFees
    {
        [Key]
        public Guid FeedID { get; set; }

        public decimal AuctionLengthFee { get; set; }

        public decimal BoldFee { get; set; }

        public decimal BuyItNowFee { get; set; }

        public decimal CategoryFeaturedFee { get; set; }

        public decimal FeaturedFee { get; set; }

        public decimal GalleryPlusFee { get; set; }

        public decimal FeaturedGalleryFee { get; set; }

        public decimal FixedPriceDurationFee { get; set; }

        public decimal GalleryFee { get; set; }

        public decimal GiftIconFee { get; set; }

        public decimal HighLightFee { get; set; }

        public decimal InsertionFee { get; set; }

        public decimal InternationalInsertionFee { get; set; }

        public decimal ListingDesignerFee { get; set; }

        public decimal ListingFee { get; set; }

        public decimal PhotoDisplayFee { get; set; }

        public decimal PhotoFee { get; set; }

        public decimal ReserveFee { get; set; }

        public decimal SchedulingFee { get; set; }

        public decimal SubtitleFee { get; set; }

        public decimal BorderFee { get; set; }

        public decimal ProPackBundleFee { get; set; }

        public decimal BasicUpgradePackBundleFee { get; set; }

        public decimal ValuePackBundleFee { get; set; }

        public decimal PrivateListingFee { get; set; }

        public decimal ProPackPlusBundleFee { get; set; }

        public decimal MotorsGermanySearchFee { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        public Guid EbayListingID { get; set; }

        public virtual EbayListing EbayListing { get; set; }
    }
}
