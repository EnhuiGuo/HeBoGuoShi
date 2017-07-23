namespace HeBoGuoShi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editCartItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "CartId", "dbo.Carts");
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.SellerProducts");
            DropIndex("dbo.CartItems", new[] { "CartId" });
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropTable("dbo.CartItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CartId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CartItems", "ProductId");
            CreateIndex("dbo.CartItems", "CartId");
            AddForeignKey("dbo.CartItems", "ProductId", "dbo.SellerProducts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CartItems", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
    }
}
