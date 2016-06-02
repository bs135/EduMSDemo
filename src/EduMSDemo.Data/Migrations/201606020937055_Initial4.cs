namespace EduMSDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubjectClassTeacher", "StaffId", "dbo.Staff");
            DropForeignKey("dbo.SubjectClassTeacher", "SubjectClassId", "dbo.SubjectClass");
            DropIndex("dbo.SubjectClassTeacher", new[] { "StaffId" });
            DropIndex("dbo.SubjectClassTeacher", new[] { "SubjectClassId" });
            AddColumn("dbo.SubjectClass", "StaffId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubjectClass", "StaffId");
            AddForeignKey("dbo.SubjectClass", "StaffId", "dbo.Staff", "Id");
            DropTable("dbo.SubjectClassTeacher");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubjectClassTeacher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Accountability = c.String(maxLength: 128),
                        StaffId = c.Int(nullable: false),
                        SubjectClassId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.SubjectClass", "StaffId", "dbo.Staff");
            DropIndex("dbo.SubjectClass", new[] { "StaffId" });
            DropColumn("dbo.SubjectClass", "StaffId");
            CreateIndex("dbo.SubjectClassTeacher", "SubjectClassId");
            CreateIndex("dbo.SubjectClassTeacher", "StaffId");
            AddForeignKey("dbo.SubjectClassTeacher", "SubjectClassId", "dbo.SubjectClass", "Id");
            AddForeignKey("dbo.SubjectClassTeacher", "StaffId", "dbo.Staff", "Id");
        }
    }
}
