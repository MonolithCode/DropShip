namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EbayListingImages
    {
        [Key]
        public Guid EbayListingImageID { get; set; }

        public Guid EbayListingID { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Image { get; set; }

        public int? Order { get; set; }

        [StringLength(1000)]
        public string Link { get; set; }

        public virtual EbayListing EbayListing { get; set; }
    }
}
