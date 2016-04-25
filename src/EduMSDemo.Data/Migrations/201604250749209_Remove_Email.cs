namespace EduMSDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Email : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Staff", "Email");
            DropColumn("dbo.Student", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "Email", c => c.String(maxLength: 256));
            AddColumn("dbo.Staff", "Email", c => c.String(maxLength: 256));
        }
    }
}
