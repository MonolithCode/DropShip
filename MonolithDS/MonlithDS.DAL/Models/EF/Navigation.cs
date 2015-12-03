using System;
using System.ComponentModel.DataAnnotations;

namespace MonlithDS.DAL.Models.EF
{
    public partial class Navigation
    {
        public Guid NavigationID { get; set; }
        public Guid TopLevelNavigationID { get; set; }

        [StringLength(200)]
        public string Label { get; set; }


    }
}
