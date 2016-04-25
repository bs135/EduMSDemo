namespace EduMSDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unique_Name : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Staff", new[] { "Name" });
            DropIndex("dbo.Student", new[] { "Name" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Student", "Name", unique: true);
            CreateIndex("dbo.Staff", "Name", unique: true);
        }
    }
}
