namespace EduMSDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_schoolyear : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Semester", "SchoolYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Semester", "SchoolYear", c => c.String(nullable: false, maxLength: 32));
        }
    }
}
