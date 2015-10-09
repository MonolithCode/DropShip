namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EbayOrderChanges
    {
        [Key]
        public Guid OrderChangeID { get; set; }

        public bool Completed { get; set; }

        public bool MarkAsShipped { get; set; }

        public bool AddTrackingNumber { get; set; }

        public bool LeaveFeedback { get; set; }

        public bool Negative { get; set; }

        [StringLength(50)]
        public string Message { get; set; }

        [Required]
        [StringLength(150)]
        public string EBayOrderID { get; set; }

        [StringLength(200)]
        public string TrackingNumber { get; set; }

        public Guid OrderID { get; set; }

        public virtual EbayOrders EbayOrders { get; set; }
    }
}
