namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EbayAPI")]
    public partial class EbayAPI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EbayAPI()
        {
            EbayAccount = new HashSet<EbayAccount>();
        }

        public Guid EbayApiID { get; set; }

        [Required]
        [StringLength(80)]
        public string AppID { get; set; }

        [Required]
        [StringLength(80)]
        public string DevID { get; set; }

        [Required]
        [StringLength(80)]
        public string AuthCert { get; set; }

        public string Token { get; set; }

        [StringLength(80)]
        public string Runame { get; set; }

        public string SandBoxToken { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EbayAccount> EbayAccount { get; set; }
    }
}
