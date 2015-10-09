namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AmazonItemSearch")]
    public partial class AmazonItemSearch
    {
        public Guid AmazonItemSearchID { get; set; }

        [Required]
        [StringLength(20)]
        public string ASIN { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public decimal? Price { get; set; }

        public DateTime? LastCheckedDate { get; set; }

        public Guid RUID { get; set; }
    }
}
