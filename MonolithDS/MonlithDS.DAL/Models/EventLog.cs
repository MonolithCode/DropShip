namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventLog")]
    public partial class EventLog
    {
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Event { get; set; }

        [Required]
        public string Message { get; set; }

        public Guid? Employee { get; set; }

        [Required]
        [StringLength(50)]
        public string IPAddress { get; set; }

        public Guid? EbayListingID { get; set; }

        public Guid? OrderID { get; set; }
    }
}
