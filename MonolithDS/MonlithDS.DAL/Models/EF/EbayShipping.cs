namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EbayShipping")]
    public partial class EbayShipping
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EbayShipping()
        {
            EbayListing = new HashSet<EbayListing>();
        }

        [Key]
        public Guid ShippingID { get; set; }

        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }

        [Required]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EbayListing> EbayListing { get; set; }
    }
}
