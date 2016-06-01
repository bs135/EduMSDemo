namespace EduMSDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Department", new[] { "Abbreviation" });
            AddColumn("dbo.Department", "FaxNumber", c => c.String(maxLength: 256));
            DropColumn("dbo.Department", "Abbreviation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Department", "Abbreviation", c => c.String(nullable: false, maxLength: 32));
            DropColumn("dbo.Department", "FaxNumber");
            CreateIndex("dbo.Department", "Abbreviation", unique: true);
        }
    }
}
