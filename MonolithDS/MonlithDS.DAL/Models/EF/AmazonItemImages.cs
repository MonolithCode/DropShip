namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AmazonItemImages
    {
        [Key]
        public int AmazonImagesID { get; set; }

        public Guid AmazonItemID { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Image { get; set; }

        public int? Order { get; set; }

        public virtual AmazonItem AmazonItem { get; set; }
    }
}
