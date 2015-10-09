namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AmazonItemFeatures
    {
        [Key]
        public Guid AmazonItemFeatureID { get; set; }

        [Required]
        public string Description { get; set; }

        public Guid AmazonItemID { get; set; }

        public int? Order { get; set; }

        public virtual AmazonItem AmazonItem { get; set; }
    }
}
