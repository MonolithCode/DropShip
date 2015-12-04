using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonlithDS.DAL.Models
{
    [Table("MenuItems")]
    public partial class MenuItem
    {
        public MenuItem()
        {
            MenuItemId = new Guid();
        }

        public string Label { get; set; }

        public Guid MenuItemId { get; set; }
        public Guid TopMenuItemId { get; set; }
    }
}
