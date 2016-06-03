namespace EduMSDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScoreRecord", "MidTermScore", c => c.Double());
            AddColumn("dbo.ScoreRecord", "TermScore", c => c.Double());
            AddColumn("dbo.ScoreRecord", "FinalScore", c => c.Double());
            AddColumn("dbo.ScoreRecord", "DateOfScore", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScoreRecord", "DateOfScore");
            DropColumn("dbo.ScoreRecord", "FinalScore");
            DropColumn("dbo.ScoreRecord", "TermScore");
            DropColumn("dbo.ScoreRecord", "MidTermScore");
        }
    }
}
