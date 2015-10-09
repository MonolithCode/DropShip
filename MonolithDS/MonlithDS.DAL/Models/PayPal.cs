namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayPal")]
    public partial class PayPal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PayPal()
        {
            EbayAccount = new HashSet<EbayAccount>();
        }

        public Guid PaypalID { get; set; }

        [Required]
        [StringLength(100)]
        public string ApiUsername { get; set; }

        [Required]
        [StringLength(100)]
        public string ApiPassword { get; set; }

        [Required]
        [StringLength(150)]
        public string ApiSignature { get; set; }

        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }

        [StringLength(80)]
        public string EmailAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EbayAccount> EbayAccount { get; set; }
    }
}
