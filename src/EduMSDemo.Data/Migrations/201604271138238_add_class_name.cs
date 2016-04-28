namespace EduMSDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_class_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectClass", "Name", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubjectClass", "Name");
        }
    }
}
