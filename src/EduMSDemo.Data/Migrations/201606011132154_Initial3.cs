namespace EduMSDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subject", "NameEn", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Subject", "NumberOfPeriods", c => c.Int(nullable: false));
            AddColumn("dbo.Subject", "NumberOfCredits", c => c.Int(nullable: false));
            DropColumn("dbo.Subject", "Credits");
            DropColumn("dbo.Subject", "AcademicCredits");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subject", "AcademicCredits", c => c.Int(nullable: false));
            AddColumn("dbo.Subject", "Credits", c => c.Int(nullable: false));
            DropColumn("dbo.Subject", "NumberOfCredits");
            DropColumn("dbo.Subject", "NumberOfPeriods");
            DropColumn("dbo.Subject", "NameEn");
        }
    }
}
