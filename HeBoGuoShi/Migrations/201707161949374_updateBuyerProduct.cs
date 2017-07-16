namespace HeBoGuoShi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBuyerProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BuyerProducts", "OwnerProductId", "dbo.OwnerProducts");
            DropIndex("dbo.BuyerProducts", new[] { "OwnerProductId" });
            AddColumn("dbo.BuyerProducts", "SellerProductId", c => c.Guid(nullable: false));
            CreateIndex("dbo.BuyerProducts", "SellerProductId");
            AddForeignKey("dbo.BuyerProducts", "SellerProductId", "dbo.SellerProducts", "Id", cascadeDelete: true);
            DropColumn("dbo.BuyerProducts", "OwnerProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BuyerProducts", "OwnerProductId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.BuyerProducts", "SellerProductId", "dbo.SellerProducts");
            DropIndex("dbo.BuyerProducts", new[] { "SellerProductId" });
            DropColumn("dbo.BuyerProducts", "SellerProductId");
            CreateIndex("dbo.BuyerProducts", "OwnerProductId");
            AddForeignKey("dbo.BuyerProducts", "OwnerProductId", "dbo.OwnerProducts", "Id", cascadeDelete: true);
        }
    }
}
