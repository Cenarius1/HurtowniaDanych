namespace DWH.Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInRawPrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarDetails", "Price", c => c.String());
            AlterColumn("dbo.CarDetails", "PriceRaw", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarDetails", "PriceRaw", c => c.String());
            AlterColumn("dbo.CarDetails", "Price", c => c.Int(nullable: false));
        }
    }
}
