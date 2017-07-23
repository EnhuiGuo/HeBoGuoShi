namespace HeBoGuoShi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editCartItemPK : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CartItems");
            AlterColumn("dbo.CartItems", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.CartItems", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CartItems");
            AlterColumn("dbo.CartItems", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.CartItems", "Id");
        }
    }
}
