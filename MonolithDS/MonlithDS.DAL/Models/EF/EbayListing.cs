namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EbayListing")]
    public sealed partial class EbayListing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EbayListing()
        {
            EbayListingErrors = new HashSet<EbayListingErrors>();
            EbayListingFeatures = new HashSet<EbayListingFeatures>();
            EbayListingImages = new HashSet<EbayListingImages>();
            ListingFees = new HashSet<ListingFees>();
            Price = 0.00m;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            EbayListingID = new Guid();
        }

        public Guid EbayListingID { get; set; }

        public Guid? EbayAccountID { get; set; }

        public Guid? AmazonItemID { get; set; }

        [StringLength(400)]
        public string EbayItemID { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public string DescriptionHtml { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdatedDate { get; set; }

        public bool Sold { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? SoldDate { get; set; }

        public bool Retracted { get; set; }

        public decimal Price { get; set; }

        public decimal Postage { get; set; }

        [StringLength(5)]
        public string Currency { get; set; }

        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        [StringLength(55)]
        public string SubTitle { get; set; }

        public int CategoryID { get; set; }

        public int? PaypalID { get; set; }

        public bool PriceFixed { get; set; }

        public Guid ConditionID { get; set; }

        public int Quantity { get; set; }

        [StringLength(200)]
        public string DescriptionHeader { get; set; }

        [StringLength(200)]
        public string DescriptionSubHeader { get; set; }

        public string DescriptionContent { get; set; }

        [StringLength(2000)]
        public string DescriptionPayment { get; set; }

        public Guid? DescriptionShipping { get; set; }

        public Guid? DescriptionReturnPolicy { get; set; }

        public Guid? DescriptionFeedback { get; set; }

        public Guid? DescriptionTaxes { get; set; }

        public bool InProgress { get; set; }

        public Guid? EmployeeID { get; set; }

        public Guid? ListingDurationID { get; set; }

        public bool ReadyToSubmit { get; set; }

        public bool Online { get; set; }

        public bool ReadyForEbayList { get; set; }

        [StringLength(400)]
        public string ListingUrl { get; set; }

        public bool ChangesToApply { get; set; }

        public decimal? NewPrice { get; set; }

        public bool AcceptNewPrice { get; set; }

        public bool RejectNewPrice { get; set; }

        public AmazonItem AmazonItem { get; set; }

        public EbayAccount EbayAccount { get; set; }

        public EbayCategories EbayCategories { get; set; }

        public EbayFeedback EbayFeedback { get; set; }

        public EbayListingCondition EbayListingCondition { get; set; }

        public EbayListingDuration EbayListingDuration { get; set; }

        public EbayReturnPolicy EbayReturnPolicy { get; set; }

        public EbayShipping EbayShipping { get; set; }

        public EbayTaxes EbayTaxes { get; set; }

        public Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<EbayListingErrors> EbayListingErrors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<EbayListingFeatures> EbayListingFeatures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<EbayListingImages> EbayListingImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ListingFees> ListingFees { get; set; }
    }
}
