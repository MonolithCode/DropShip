namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EbayAccountFeeDates
    {
        [Key]
        public Guid FeeRemovalID { get; set; }

        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        public DateTime Date { get; set; }

        public Guid EbayAccountID { get; set; }

        public virtual EbayAccount EbayAccount { get; set; }
    }
}
