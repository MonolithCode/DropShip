namespace MonlithDS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EbayListing_Defaults : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE [dbo].[EbayListing] SET Price = 0.00 WHERE Price IS NULL");
            Sql("UPDATE [dbo].[EbayListing] SET Postage = 0.00 WHERE Postage IS NULL");
            AlterColumn("dbo.EbayListing", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValue: DateTime.Now));
            AlterColumn("dbo.EbayListing", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValueSql:"0.00"));
            AlterColumn("dbo.EbayListing", "Postage", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValueSql: "0.00"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EbayListing", "Postage", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.EbayListing", "Price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.EbayListing", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
