namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EbayOrders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EbayOrders()
        {
            EbayOrderChanges = new HashSet<EbayOrderChanges>();
        }

        [Key]
        public Guid OrderID { get; set; }

        [Required]
        [StringLength(150)]
        public string EbayOrderID { get; set; }

        public decimal AmountPaid { get; set; }

        [StringLength(100)]
        public string eBayPaymentStatus { get; set; }

        [StringLength(100)]
        public string PaymentMethod { get; set; }

        [StringLength(100)]
        public string ShippingName { get; set; }

        [StringLength(100)]
        public string ShippingStreet1 { get; set; }

        [StringLength(100)]
        public string ShippingStreet2 { get; set; }

        [StringLength(100)]
        public string ShippingCityName { get; set; }

        [StringLength(100)]
        public string ShippingStateOrProvince { get; set; }

        [StringLength(100)]
        public string ShippingCountry { get; set; }

        [StringLength(100)]
        public string AddressCountryName { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(400)]
        public string EbayItemID { get; set; }

        public int QuantityPurchased { get; set; }

        [Required]
        [StringLength(150)]
        public string PaymentStatus { get; set; }

        public decimal PaymentAmount { get; set; }

        [Required]
        [StringLength(200)]
        public string TransactionID { get; set; }

        public bool Shipped { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ShippedTime { get; set; }

        [StringLength(150)]
        public string TrackingNumber { get; set; }

        public bool TrackingNumberAdded { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(50)]
        public string CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDateReadable { get; set; }

        public bool OrderedOnAmazon { get; set; }

        public bool StockUpdated { get; set; }

        [StringLength(50)]
        public string AmazonOrderRef { get; set; }

        public DateTime LastUpdated { get; set; }

        [StringLength(150)]
        public string AmazonShipmentID { get; set; }

        [StringLength(50)]
        public string AmazonOrderStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EbayOrderChanges> EbayOrderChanges { get; set; }
    }
}
