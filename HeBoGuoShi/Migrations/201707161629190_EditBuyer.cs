namespace HeBoGuoShi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBuyer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BuyerProducts", "SellerId", "dbo.AspNetUsers");
            DropIndex("dbo.BuyerProducts", new[] { "SellerId" });
            DropColumn("dbo.BuyerProducts", "SellerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BuyerProducts", "SellerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BuyerProducts", "SellerId");
            AddForeignKey("dbo.BuyerProducts", "SellerId", "dbo.AspNetUsers", "Id");
        }
    }
}
