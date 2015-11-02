using System;
    
namespace MonolithDS.Domain.Paging
{
    public class MenuItem
    {
        public string Label { get; set; }
        public Guid MenuItemId { get; set; }
        public Guid TopMenuItemId { get; set; }

    }
}
