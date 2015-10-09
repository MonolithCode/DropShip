namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessProfile")]
    public partial class AccessProfile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccessProfile()
        {
            Employee = new HashSet<Employee>();
        }

        public Guid AccessProfileID { get; set; }

        public bool AdminPanel { get; set; }

        public bool EbayListingsCreation { get; set; }

        public bool EbayItemSubmission { get; set; }

        [Required]
        [StringLength(80)]
        public string ProfileDisplayName { get; set; }

        public bool DashBoard { get; set; }

        public bool AdminUsers { get; set; }

        public bool AdminProfiles { get; set; }

        public bool AdminService { get; set; }

        public bool AdminEbay { get; set; }

        public bool AdminPaypal { get; set; }

        public bool AdminAttributes { get; set; }

        public bool AdminRestrictions { get; set; }

        public bool AdminTemplates { get; set; }

        public bool ProductAdd { get; set; }

        public bool ProductItems { get; set; }

        public bool ProductInProgress { get; set; }

        public bool ProductForReview { get; set; }

        public bool ProductFinalStage { get; set; }

        public bool ProductLiveListings { get; set; }

        public bool AmazonAccounts { get; set; }

        public bool Cards { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
