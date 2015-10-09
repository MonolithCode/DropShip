namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AmazonItem")]
    public partial class AmazonItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AmazonItem()
        {
            AmazonItemFeatures = new HashSet<AmazonItemFeatures>();
            AmazonItemImages = new HashSet<AmazonItemImages>();
            EbayListing = new HashSet<EbayListing>();
        }

        public Guid AmazonItemID { get; set; }

        [Required]
        [StringLength(20)]
        public string ASIN { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedDate { get; set; }

        public decimal? Price { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LastCheckedDate { get; set; }

        public decimal? Rating { get; set; }

        [StringLength(50)]
        public string UPC { get; set; }

        [StringLength(50)]
        public string ISBN { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string MPN { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [StringLength(300)]
        public string Url { get; set; }

        public string OfferListingID { get; set; }

        [StringLength(250)]
        public string OffersUrl { get; set; }

        public bool OutOfStock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AmazonItemFeatures> AmazonItemFeatures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AmazonItemImages> AmazonItemImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EbayListing> EbayListing { get; set; }
    }
}
