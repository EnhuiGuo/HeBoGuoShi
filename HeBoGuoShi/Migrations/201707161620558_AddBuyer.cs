namespace HeBoGuoShi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBuyer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyerProducts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        SellerId = c.String(maxLength: 128),
                        OwnerProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OwnerProducts", t => t.OwnerProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.SellerId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SellerId)
                .Index(t => t.OwnerProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyerProducts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BuyerProducts", "SellerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BuyerProducts", "OwnerProductId", "dbo.OwnerProducts");
            DropIndex("dbo.BuyerProducts", new[] { "OwnerProductId" });
            DropIndex("dbo.BuyerProducts", new[] { "SellerId" });
            DropIndex("dbo.BuyerProducts", new[] { "UserId" });
            DropTable("dbo.BuyerProducts");
        }
    }
}
