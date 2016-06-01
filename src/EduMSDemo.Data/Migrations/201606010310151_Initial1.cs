namespace EduMSDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faculty", "FaxNumber", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Faculty", "FaxNumber");
        }
    }
}
