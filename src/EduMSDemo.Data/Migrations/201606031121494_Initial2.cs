namespace EduMSDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ScoreRecord", "SubjectId", "dbo.Subject");
            DropIndex("dbo.ScoreRecord", new[] { "SubjectId" });
            DropColumn("dbo.ScoreRecord", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScoreRecord", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ScoreRecord", "SubjectId");
            AddForeignKey("dbo.ScoreRecord", "SubjectId", "dbo.Subject", "Id");
        }
    }
}
