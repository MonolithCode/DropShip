namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PriceRanges
    {
        [Key]
        public Guid RangeID { get; set; }

        public decimal Min { get; set; }

        public decimal Max { get; set; }

        public decimal Profit { get; set; }

        [Required]
        [StringLength(50)]
        public string Currency { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(197)]
        public string DisplayName { get; set; }
    }
}
