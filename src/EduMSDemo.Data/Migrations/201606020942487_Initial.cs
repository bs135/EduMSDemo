namespace EduMSDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 32),
                        Passhash = c.String(nullable: false, maxLength: 64),
                        Email = c.String(nullable: false, maxLength: 256),
                        IsLocked = c.Boolean(nullable: false),
                        RecoveryToken = c.String(maxLength: 36),
                        RecoveryTokenExpirationDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RoleId = c.Int(),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Title, unique: true);
            
            CreateTable(
                "dbo.RolePermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permission", t => t.PermissionId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Area = c.String(maxLength: 64),
                        Controller = c.String(nullable: false, maxLength: 64),
                        Action = c.String(nullable: false, maxLength: 64),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 32),
                        Name = c.String(nullable: false, maxLength: 128),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlaceOfBirth = c.String(),
                        Gender = c.String(),
                        Address = c.String(maxLength: 512),
                        PhoneNumber = c.String(maxLength: 256),
                        AccountId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.Code, unique: true)
                .Index(t => t.AccountId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.FacultyManageBoard",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DeanId = c.Int(nullable: false),
                        ViceDean1Id = c.Int(nullable: false),
                        ViceDean2Id = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Staff", t => t.DeanId)
                .ForeignKey("dbo.Staff", t => t.ViceDean1Id)
                .ForeignKey("dbo.Staff", t => t.ViceDean2Id)
                .Index(t => t.DeanId)
                .Index(t => t.ViceDean1Id)
                .Index(t => t.ViceDean2Id);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Address = c.String(maxLength: 512),
                        Email = c.String(maxLength: 256),
                        PhoneNumber = c.String(maxLength: 256),
                        FaxNumber = c.String(maxLength: 256),
                        FacultyId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculty", t => t.FacultyId)
                .Index(t => t.Name, unique: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(nullable: false, maxLength: 32),
                        Name = c.String(nullable: false, maxLength: 128),
                        Address = c.String(maxLength: 512),
                        Email = c.String(maxLength: 256),
                        PhoneNumber = c.String(maxLength: 256),
                        FaxNumber = c.String(maxLength: 256),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Abbreviation, unique: true)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 32),
                        Name = c.String(nullable: false, maxLength: 128),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FacultyId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculty", t => t.FacultyId)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Curriculum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        FacultyId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Faculty", t => t.FacultyId)
                .Index(t => t.Name, unique: true)
                .Index(t => t.FacultyId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CurriculumDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurriculumId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        CurriculumTypeId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Curriculum", t => t.CurriculumId)
                .ForeignKey("dbo.CurriculumType", t => t.CurriculumTypeId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.CurriculumId)
                .Index(t => t.SubjectId)
                .Index(t => t.CurriculumTypeId);
            
            CreateTable(
                "dbo.CurriculumType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 32),
                        Name = c.String(nullable: false, maxLength: 128),
                        NameEn = c.String(nullable: false, maxLength: 128),
                        NumberOfPeriods = c.Int(nullable: false),
                        NumberOfCredits = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.PreSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PreOfSubjectId = c.Int(nullable: false),
                        SubjectOfPreId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.PreOfSubjectId)
                .ForeignKey("dbo.Subject", t => t.SubjectOfPreId)
                .Index(t => t.PreOfSubjectId)
                .Index(t => t.SubjectOfPreId);
            
            CreateTable(
                "dbo.ScoreRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegigterDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        StudentId = c.Int(nullable: false),
                        SubjectClassId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectClassId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.ScoreRecordDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MidTermScore = c.Double(nullable: false),
                        TermScore = c.Double(nullable: false),
                        FinalScore = c.Double(nullable: false),
                        DateOfScore = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ScoreRecordId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScoreRecord", t => t.ScoreRecordId)
                .Index(t => t.ScoreRecordId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 32),
                        Name = c.String(nullable: false, maxLength: 128),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlaceOfBirth = c.String(),
                        Gender = c.String(),
                        Address = c.String(maxLength: 512),
                        PhoneNumber = c.String(maxLength: 256),
                        AccountId = c.Int(nullable: false),
                        StudentClassId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .ForeignKey("dbo.StudentClass", t => t.StudentClassId)
                .Index(t => t.Code, unique: true)
                .Index(t => t.AccountId)
                .Index(t => t.StudentClassId);
            
            CreateTable(
                "dbo.BonusScore",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Double(nullable: false),
                        Note = c.String(),
                        StudentId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(nullable: false, maxLength: 32),
                        Name = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        StaffId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Staff", t => t.StaffId)
                .Index(t => t.Abbreviation, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CourseId)
                .Index(t => t.StaffId);
            
            CreateTable(
                "dbo.SubjectClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        StaffId = c.Int(nullable: false),
                        RoomOfMidtermExamId = c.Int(nullable: false),
                        RoomOfTermExamId = c.Int(nullable: false),
                        RoomOfClassId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassRoom", t => t.RoomOfClassId)
                .ForeignKey("dbo.ClassRoom", t => t.RoomOfMidtermExamId)
                .ForeignKey("dbo.ClassRoom", t => t.RoomOfTermExamId)
                .ForeignKey("dbo.Semester", t => t.SemesterId)
                .ForeignKey("dbo.Staff", t => t.StaffId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId)
                .Index(t => t.StaffId)
                .Index(t => t.RoomOfMidtermExamId)
                .Index(t => t.RoomOfTermExamId)
                .Index(t => t.RoomOfClassId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.ClassRoom",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 32),
                        Name = c.String(nullable: false, maxLength: 128),
                        Capacity = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Building", t => t.BuildingId)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.Building",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 32),
                        Name = c.String(nullable: false, maxLength: 128),
                        RoomCount = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Semester",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.AuditLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(),
                        Action = c.String(nullable: false, maxLength: 16),
                        EntityName = c.String(nullable: false, maxLength: 64),
                        EntityId = c.Int(nullable: false),
                        Changes = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemSetting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 64),
                        ValueString = c.String(maxLength: 256),
                        ValueDouble = c.Double(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Key, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacultyManageBoard", "ViceDean2Id", "dbo.Staff");
            DropForeignKey("dbo.FacultyManageBoard", "ViceDean1Id", "dbo.Staff");
            DropForeignKey("dbo.Staff", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Department", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.Course", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.Curriculum", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.PreSubject", "SubjectOfPreId", "dbo.Subject");
            DropForeignKey("dbo.SubjectClass", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectClass", "StaffId", "dbo.Staff");
            DropForeignKey("dbo.SubjectClass", "SemesterId", "dbo.Semester");
            DropForeignKey("dbo.ScoreRecord", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.SubjectClass", "RoomOfTermExamId", "dbo.ClassRoom");
            DropForeignKey("dbo.SubjectClass", "RoomOfMidtermExamId", "dbo.ClassRoom");
            DropForeignKey("dbo.SubjectClass", "RoomOfClassId", "dbo.ClassRoom");
            DropForeignKey("dbo.ClassRoom", "BuildingId", "dbo.Building");
            DropForeignKey("dbo.ScoreRecord", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Student", "StudentClassId", "dbo.StudentClass");
            DropForeignKey("dbo.StudentClass", "StaffId", "dbo.Staff");
            DropForeignKey("dbo.StudentClass", "CourseId", "dbo.Course");
            DropForeignKey("dbo.ScoreRecord", "StudentId", "dbo.Student");
            DropForeignKey("dbo.BonusScore", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "AccountId", "dbo.Account");
            DropForeignKey("dbo.ScoreRecordDetail", "ScoreRecordId", "dbo.ScoreRecord");
            DropForeignKey("dbo.PreSubject", "PreOfSubjectId", "dbo.Subject");
            DropForeignKey("dbo.Subject", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.CurriculumDetail", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.CurriculumDetail", "CurriculumTypeId", "dbo.CurriculumType");
            DropForeignKey("dbo.CurriculumDetail", "CurriculumId", "dbo.Curriculum");
            DropForeignKey("dbo.Curriculum", "CourseId", "dbo.Course");
            DropForeignKey("dbo.FacultyManageBoard", "DeanId", "dbo.Staff");
            DropForeignKey("dbo.Staff", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Account", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RolePermission", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RolePermission", "PermissionId", "dbo.Permission");
            DropIndex("dbo.SystemSetting", new[] { "Key" });
            DropIndex("dbo.Semester", new[] { "Name" });
            DropIndex("dbo.Building", new[] { "Name" });
            DropIndex("dbo.Building", new[] { "Code" });
            DropIndex("dbo.ClassRoom", new[] { "BuildingId" });
            DropIndex("dbo.ClassRoom", new[] { "Name" });
            DropIndex("dbo.ClassRoom", new[] { "Code" });
            DropIndex("dbo.SubjectClass", new[] { "SemesterId" });
            DropIndex("dbo.SubjectClass", new[] { "RoomOfClassId" });
            DropIndex("dbo.SubjectClass", new[] { "RoomOfTermExamId" });
            DropIndex("dbo.SubjectClass", new[] { "RoomOfMidtermExamId" });
            DropIndex("dbo.SubjectClass", new[] { "StaffId" });
            DropIndex("dbo.SubjectClass", new[] { "SubjectId" });
            DropIndex("dbo.StudentClass", new[] { "StaffId" });
            DropIndex("dbo.StudentClass", new[] { "CourseId" });
            DropIndex("dbo.StudentClass", new[] { "Name" });
            DropIndex("dbo.StudentClass", new[] { "Abbreviation" });
            DropIndex("dbo.BonusScore", new[] { "StudentId" });
            DropIndex("dbo.Student", new[] { "StudentClassId" });
            DropIndex("dbo.Student", new[] { "AccountId" });
            DropIndex("dbo.Student", new[] { "Code" });
            DropIndex("dbo.ScoreRecordDetail", new[] { "ScoreRecordId" });
            DropIndex("dbo.ScoreRecord", new[] { "SubjectId" });
            DropIndex("dbo.ScoreRecord", new[] { "SubjectClassId" });
            DropIndex("dbo.ScoreRecord", new[] { "StudentId" });
            DropIndex("dbo.PreSubject", new[] { "SubjectOfPreId" });
            DropIndex("dbo.PreSubject", new[] { "PreOfSubjectId" });
            DropIndex("dbo.Subject", new[] { "DepartmentId" });
            DropIndex("dbo.Subject", new[] { "Name" });
            DropIndex("dbo.Subject", new[] { "Code" });
            DropIndex("dbo.CurriculumType", new[] { "Name" });
            DropIndex("dbo.CurriculumDetail", new[] { "CurriculumTypeId" });
            DropIndex("dbo.CurriculumDetail", new[] { "SubjectId" });
            DropIndex("dbo.CurriculumDetail", new[] { "CurriculumId" });
            DropIndex("dbo.Curriculum", new[] { "CourseId" });
            DropIndex("dbo.Curriculum", new[] { "FacultyId" });
            DropIndex("dbo.Curriculum", new[] { "Name" });
            DropIndex("dbo.Course", new[] { "FacultyId" });
            DropIndex("dbo.Course", new[] { "Name" });
            DropIndex("dbo.Course", new[] { "Code" });
            DropIndex("dbo.Faculty", new[] { "Name" });
            DropIndex("dbo.Faculty", new[] { "Abbreviation" });
            DropIndex("dbo.Department", new[] { "FacultyId" });
            DropIndex("dbo.Department", new[] { "Name" });
            DropIndex("dbo.FacultyManageBoard", new[] { "ViceDean2Id" });
            DropIndex("dbo.FacultyManageBoard", new[] { "ViceDean1Id" });
            DropIndex("dbo.FacultyManageBoard", new[] { "DeanId" });
            DropIndex("dbo.Staff", new[] { "DepartmentId" });
            DropIndex("dbo.Staff", new[] { "AccountId" });
            DropIndex("dbo.Staff", new[] { "Code" });
            DropIndex("dbo.RolePermission", new[] { "PermissionId" });
            DropIndex("dbo.RolePermission", new[] { "RoleId" });
            DropIndex("dbo.Role", new[] { "Title" });
            DropIndex("dbo.Account", new[] { "RoleId" });
            DropIndex("dbo.Account", new[] { "Email" });
            DropIndex("dbo.Account", new[] { "Username" });
            DropTable("dbo.SystemSetting");
            DropTable("dbo.AuditLog");
            DropTable("dbo.Semester");
            DropTable("dbo.Building");
            DropTable("dbo.ClassRoom");
            DropTable("dbo.SubjectClass");
            DropTable("dbo.StudentClass");
            DropTable("dbo.BonusScore");
            DropTable("dbo.Student");
            DropTable("dbo.ScoreRecordDetail");
            DropTable("dbo.ScoreRecord");
            DropTable("dbo.PreSubject");
            DropTable("dbo.Subject");
            DropTable("dbo.CurriculumType");
            DropTable("dbo.CurriculumDetail");
            DropTable("dbo.Curriculum");
            DropTable("dbo.Course");
            DropTable("dbo.Faculty");
            DropTable("dbo.Department");
            DropTable("dbo.FacultyManageBoard");
            DropTable("dbo.Staff");
            DropTable("dbo.Permission");
            DropTable("dbo.RolePermission");
            DropTable("dbo.Role");
            DropTable("dbo.Account");
        }
    }
}
