namespace EduMSDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Subject", new[] { "Name" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Subject", "Name", unique: true);
        }
    }
}
