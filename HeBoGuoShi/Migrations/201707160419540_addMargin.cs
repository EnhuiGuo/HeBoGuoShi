namespace HeBoGuoShi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMargin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OwnerProducts", "Margin", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OwnerProducts", "Margin");
        }
    }
}
