namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EbayListingErrors
    {
        [Key]
        public Guid ErrorID { get; set; }

        public Guid EbayListingID { get; set; }

        public string Message { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        public virtual EbayListing EbayListing { get; set; }
    }
}
