namespace MonlithDS.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MenuItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        MenuItemId = c.Guid(nullable: false, defaultValueSql: "NEWID()"),
                        Label = c.String(),
                        TopMenuItemId = c.Guid(nullable: true),
                    })
                .PrimaryKey(t => t.MenuItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuItems");
        }
    }
}
