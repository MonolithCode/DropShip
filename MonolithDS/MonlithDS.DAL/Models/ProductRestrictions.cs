namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductRestrictions
    {
        public int MinRating { get; set; }

        public bool UseRating { get; set; }

        public bool AllowAdultProducts { get; set; }

        public Guid ID { get; set; }
    }
}
