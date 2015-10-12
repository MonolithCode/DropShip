namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EbayAccount")]
    public partial class EbayAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EbayAccount()
        {
            EbayAccountFeeDates = new HashSet<EbayAccountFeeDates>();
            EbayListing = new HashSet<EbayListing>();
        }

        public Guid EbayAccountID { get; set; }

        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }

        public string AccessToken { get; set; }

        public bool Authorised { get; set; }

        public Guid? EbayApiID { get; set; }

        public Guid? PayPalID { get; set; }

        public Guid SecretKey { get; set; }

        public Guid? TemplateID { get; set; }

        public Guid? AmazonAccountID { get; set; }

        [StringLength(50)]
        public string LocationPostalCode { get; set; }

        public virtual AmazonAccount AmazonAccount { get; set; }

        public virtual EbayAPI EbayAPI { get; set; }

        public virtual PayPal PayPal { get; set; }

        public virtual Template Template { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EbayAccountFeeDates> EbayAccountFeeDates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EbayListing> EbayListing { get; set; }
    }
}
