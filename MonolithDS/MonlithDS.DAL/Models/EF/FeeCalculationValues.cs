namespace MonlithDS.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FeeCalculationValues
    {
        [Key]
        public Guid FeeCalcID { get; set; }

        public decimal PaypalPercentage { get; set; }

        public decimal PaypalFixedAdditionalCost { get; set; }

        public decimal PaypalInternationalFeePercentage { get; set; }

        public decimal EbayInsertionFee { get; set; }

        public decimal EbayFVFeePercentage { get; set; }
    }
}
