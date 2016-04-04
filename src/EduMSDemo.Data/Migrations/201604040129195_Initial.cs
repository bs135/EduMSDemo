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
                        Name = c.String(nullable: false, maxLength: 128),
                        Position = c.String(maxLength: 128),
                        Phone = c.String(maxLength: 32),
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
                "dbo.ProductGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 512),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SKU = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false, maxLength: 256),
                        StockQuanlity = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ProductGroupId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductGroup", t => t.ProductGroupId)
                .Index(t => t.SKU, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.ProductGroupId);
            
            CreateTable(
                "dbo.SystemSetting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValueString = c.String(maxLength: 64),
                        ValueType = c.Int(nullable: false),
                        ValueFloat = c.Double(nullable: false),
                        ValueInt = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ProductGroupId", "dbo.ProductGroup");
            DropForeignKey("dbo.Account", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RolePermission", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RolePermission", "PermissionId", "dbo.Permission");
            DropIndex("dbo.Product", new[] { "ProductGroupId" });
            DropIndex("dbo.Product", new[] { "Name" });
            DropIndex("dbo.Product", new[] { "SKU" });
            DropIndex("dbo.ProductGroup", new[] { "Name" });
            DropIndex("dbo.RolePermission", new[] { "PermissionId" });
            DropIndex("dbo.RolePermission", new[] { "RoleId" });
            DropIndex("dbo.Role", new[] { "Title" });
            DropIndex("dbo.Account", new[] { "RoleId" });
            DropIndex("dbo.Account", new[] { "Email" });
            DropIndex("dbo.Account", new[] { "Username" });
            DropTable("dbo.SystemSetting");
            DropTable("dbo.Product");
            DropTable("dbo.ProductGroup");
            DropTable("dbo.AuditLog");
            DropTable("dbo.Permission");
            DropTable("dbo.RolePermission");
            DropTable("dbo.Role");
            DropTable("dbo.Account");
        }
    }
}
