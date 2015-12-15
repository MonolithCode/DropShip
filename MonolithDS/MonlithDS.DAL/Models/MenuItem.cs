namespace MonlithDS.DAL.Models
{
    public partial class MenuItem
    {
        public MonolithDS.Domain.Paging.MenuItem ToDomainObject()
        {
            return new MonolithDS.Domain.Paging.MenuItem
            {
                MenuItemId = MenuItemId,
                Label = Label,
                TopMenuItemId = TopMenuItemId
            };
        }
    }
}
