namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ServiceSettings
    {
        public Guid ServiceSettingsID { get; set; }

        public int CheckEvery { get; set; }

        public bool Disabled { get; set; }

        public bool EmailFailures { get; set; }

        [StringLength(400)]
        public string Emails { get; set; }

        public bool RunOnStart { get; set; }

        public bool UseFixedPriceAddition { get; set; }

        public decimal FixedPriceValue { get; set; }

        public decimal PercentageValue { get; set; }

        public bool RoundUpTo99 { get; set; }

        public bool ReducePriceIfLowers { get; set; }

        public DateTime LastAmazonOrderScrape { get; set; }
    }
}
