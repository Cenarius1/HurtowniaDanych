namespace DWH.Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RawPriceToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarDetails", "PriceRaw", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarDetails", "PriceRaw", c => c.Int(nullable: false));
        }
    }
}
