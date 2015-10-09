namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EbayCategories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EbayCategories()
        {
            EbayListing = new HashSet<EbayListing>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryID { get; set; }

        public int CategoryLevel { get; set; }

        [Required]
        [StringLength(80)]
        public string CategoryName { get; set; }

        public int ParentID { get; set; }

        public bool AutoPayEnabled { get; set; }

        public bool BestOfferEnabled { get; set; }

        [Required]
        [StringLength(400)]
        public string FullName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EbayListing> EbayListing { get; set; }
    }
}
