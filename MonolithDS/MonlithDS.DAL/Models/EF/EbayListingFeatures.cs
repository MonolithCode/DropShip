namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EbayListingFeatures
    {
        [Key]
        public Guid EbayListingFeatureID { get; set; }

        [Required]
        public string Description { get; set; }

        public int? Order { get; set; }

        public Guid EbayListingID { get; set; }

        public virtual EbayListing EbayListing { get; set; }
    }
}
