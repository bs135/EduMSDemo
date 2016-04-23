using EduMSDemo.Data.Core;
using EduMSDemo.Data.Logging;
using EduMSDemo.Objects;
using System;
using System.Data.Entity.Migrations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace EduMSDemo.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    internal sealed class Configuration : DbMigrationsConfiguration<Context>, IDisposable
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public Configuration()
        {
            ContextKey = "Context";
            CommandTimeout = 300;
        }

        protected override void Seed(Context context)
        {
            IAuditLogger logger = new AuditLogger(new Context(), 0);
            UnitOfWork = new UnitOfWork(context, logger);

            SeedPermissions();
            SeedRoles();
            SeedAccounts();

            SeedProducts();
        }

        #region Administration

        private void SeedPermissions()
        {
            int i = 0;
            Permission[] permissions =
            {
                #region Administration

                new Permission { Id = i++, Area = "Administration", Controller = "Accounts", Action = "Index" },
                new Permission { Id = i++, Area = "Administration", Controller = "Accounts", Action = "Create" },
                new Permission { Id = i++, Area = "Administration", Controller = "Accounts", Action = "Details" },
                new Permission { Id = i++, Area = "Administration", Controller = "Accounts", Action = "Edit" },
                new Permission { Id = i++, Area = "Administration", Controller = "Accounts", Action = "Delete" },

                new Permission { Id = i++, Area = "Administration", Controller = "Roles", Action = "Index" },
                new Permission { Id = i++, Area = "Administration", Controller = "Roles", Action = "Create" },
                new Permission { Id = i++, Area = "Administration", Controller = "Roles", Action = "Details" },
                new Permission { Id = i++, Area = "Administration", Controller = "Roles", Action = "Edit" },
                new Permission { Id = i++, Area = "Administration", Controller = "Roles", Action = "Delete" },

                new Permission { Id = i++, Area = "Administration", Controller = "SystemSettings", Action = "Index" },
                new Permission { Id = i++, Area = "Administration", Controller = "SystemSettings", Action = "Create" },
                new Permission { Id = i++, Area = "Administration", Controller = "SystemSettings", Action = "Details" },
                new Permission { Id = i++, Area = "Administration", Controller = "SystemSettings", Action = "Edit" },
                new Permission { Id = i++, Area = "Administration", Controller = "SystemSettings", Action = "Delete" },

                #endregion Administration

                #region Products

                new Permission { Id = i++, Area = "Manage", Controller = "Products", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "Products", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "Products", Action = "Details" },
                new Permission { Id = i++, Area = "Manage", Controller = "Products", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "Products", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "ProductGroups", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "ProductGroups", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "ProductGroups", Action = "Details" },
                new Permission { Id = i++, Area = "Manage", Controller = "ProductGroups", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "ProductGroups", Action = "Delete" },

                #endregion Products

                #region Buildings

                new Permission { Id = i++, Area = "Manage", Controller = "Buildings", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "Buildings", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "Buildings", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "Buildings", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "ClassRooms", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "ClassRooms", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "ClassRooms", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "ClassRooms", Action = "Delete" },

                #endregion Buildings

                #region Curriculums

                new Permission { Id = i++, Area = "Manage", Controller = "Curriculums", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "Curriculums", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "Curriculums", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "Curriculums", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "CurriculumDetails", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "CurriculumDetails", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "CurriculumDetails", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "CurriculumDetails", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "CurriculumTypes", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "CurriculumTypes", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "CurriculumTypes", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "CurriculumTypes", Action = "Delete" },

                #endregion Curriculums

                #region Scores

                new Permission { Id = i++, Area = "Manage", Controller = "Scores", Action = "Index" },

                new Permission { Id = i++, Area = "Manage", Controller = "BonusScores", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "BonusScores", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "BonusScores", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "BonusScores", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "ScoreRecords", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "ScoreRecords", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "ScoreRecords", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "ScoreRecords", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "ScoreRecordDetails", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "ScoreRecordDetails", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "ScoreRecordDetails", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "ScoreRecordDetails", Action = "Delete" },

                #endregion Scores

                #region Students

                new Permission { Id = i++, Area = "Manage", Controller = "Students", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "Students", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "Students", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "Students", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "Courses", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "Courses", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "Courses", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "Courses", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "StudentClasses", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "StudentClasses", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "StudentClasses", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "StudentClasses", Action = "Delete" },

                #endregion Students

                #region Studies

                new Permission { Id = i++, Area = "Manage", Controller = "Studies", Action = "Index" },

                new Permission { Id = i++, Area = "Manage", Controller = "Semesters", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "Semesters", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "Semesters", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "Semesters", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "SubjectClasses", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "SubjectClasses", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "SubjectClasses", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "SubjectClasses", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "SubjectClassTeachers", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "SubjectClassTeachers", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "SubjectClassTeachers", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "SubjectClassTeachers", Action = "Delete" },

                #endregion Studies

                #region Subjects

                new Permission { Id = i++, Area = "Manage", Controller = "Subjects", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "Subjects", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "Subjects", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "Subjects", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "PreSubjects", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "PreSubjects", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "PreSubjects", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "PreSubjects", Action = "Delete" },

                #endregion Subjects

                #region Teachers

                new Permission { Id = i++, Area = "Manage", Controller = "Teachers", Action = "Index" },

                new Permission { Id = i++, Area = "Manage", Controller = "Departments", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "Departments", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "Departments", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "Departments", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "Faculties", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "Faculties", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "Faculties", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "Faculties", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "FacultyManageBoards", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "FacultyManageBoards", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "FacultyManageBoards", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "FacultyManageBoards", Action = "Delete" },

                new Permission { Id = i++, Area = "Manage", Controller = "Staffs", Action = "Index" },
                new Permission { Id = i++, Area = "Manage", Controller = "Staffs", Action = "Create" },
                new Permission { Id = i++, Area = "Manage", Controller = "Staffs", Action = "Edit" },
                new Permission { Id = i++, Area = "Manage", Controller = "Staffs", Action = "Delete" },

                #endregion Teachers



            };

            Permission[] currentPermissions = UnitOfWork.Select<Permission>().ToArray();
            foreach (Permission permission in currentPermissions)
            {
                if (!permissions.Any(perm => perm.Id == permission.Id))
                {
                    UnitOfWork.DeleteRange(UnitOfWork.Select<RolePermission>().Where(role => role.PermissionId == permission.Id));
                    UnitOfWork.Delete(permission);
                }
            }

            foreach (Permission permission in permissions)
            {
                Permission currentPermission = currentPermissions.SingleOrDefault(perm => perm.Id == permission.Id);
                if (currentPermission == null)
                {
                    UnitOfWork.Insert(permission);
                }
                else
                {
                    currentPermission.Controller = permission.Controller;
                    currentPermission.Action = permission.Action;
                    currentPermission.Area = permission.Area;

                    UnitOfWork.Update(currentPermission);
                }
            }

            UnitOfWork.Commit();
        }

        private void SeedRoles()
        {
            #region Sys_Admin
            if (!UnitOfWork.Select<Role>().Any(role => role.Title == "Sys_Admin"))
            {
                UnitOfWork.Insert(new Role { Title = "Sys_Admin" });
                UnitOfWork.Commit();
            }

            Int32 adminRoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Admin").Id;
            RolePermission[] adminPermissions = UnitOfWork
                .Select<RolePermission>()
                .Where(rolePermission => rolePermission.RoleId == adminRoleId)
                .ToArray();

            foreach (Permission permission in UnitOfWork.Select<Permission>())
                if (!adminPermissions.Any(rolePermission => rolePermission.PermissionId == permission.Id))
                    UnitOfWork.Insert(new RolePermission
                    {
                        RoleId = adminRoleId,
                        PermissionId = permission.Id
                    });

            UnitOfWork.Commit();
            #endregion

            #region Sys_Manage
            if (!UnitOfWork.Select<Role>().Any(role => role.Title == "Sys_Manage"))
            {
                UnitOfWork.Insert(new Role { Title = "Sys_Manage" });
                UnitOfWork.Commit();
            }

            Int32 manageRoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Manage").Id;
            RolePermission[] managePermissions = UnitOfWork
                .Select<RolePermission>()
                .Where(rolePermission => rolePermission.RoleId == manageRoleId)
                .ToArray();

            foreach (Permission permission in UnitOfWork.Select<Permission>().Where(p => p.Area == "Manage"))
                if (!managePermissions.Any(rolePermission => rolePermission.PermissionId == permission.Id))
                    UnitOfWork.Insert(new RolePermission
                    {
                        RoleId = manageRoleId,
                        PermissionId = permission.Id
                    });

            UnitOfWork.Commit();
            #endregion
        }

        private void SeedAccounts()
        {
            Account[] accounts =
            {
                new Account
                {
                    Username = "admin",
                    Passhash = "$2a$13$yTgLCqGqgH.oHmfboFCjyuVUy5SJ2nlyckPFEZRJQrMTZWN.f1Afq", // Admin123?
                    Email = "admin@admins.com",
                    IsLocked = false,

                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Admin").Id
                }
            };

            foreach (Account account in accounts)
            {
                Account dbAccount = UnitOfWork.Select<Account>().FirstOrDefault(model => model.Username == account.Username);
                if (dbAccount != null)
                {
                    dbAccount.IsLocked = account.IsLocked;

                    UnitOfWork.Update(dbAccount);
                }
                else
                {
                    UnitOfWork.Insert(account);
                }
            }

            UnitOfWork.Commit();
        }

        #endregion

        #region Product

        private void SeedProducts()
        {
            #region productGroups
            ProductGroup[] productGroups =
            {
                new ProductGroup { Id = 1, Name = "Điện tử", Description = "" },
                new ProductGroup { Id = 2, Name = "May mặc", Description = "" },
                new ProductGroup { Id = 3, Name = "Gia dụng", Description = "" }
            };

            foreach (ProductGroup productGroup in productGroups)
            {
                ProductGroup dbproductGroup = UnitOfWork.Select<ProductGroup>().FirstOrDefault(model => model.Name == productGroup.Name);
                if (dbproductGroup == null)
                {
                    UnitOfWork.Insert(productGroup);
                }
            }

            UnitOfWork.Commit();
            #endregion

            #region products
            Product[] products =
            {
                new Product { Id = 1, Name = "Máy tính 1", SKU = "H0001", StockQuanlity = 10, IsActive = true, ProductGroupId = 1 },
                new Product { Id = 2, Name = "Máy tính 2", SKU = "H0002", StockQuanlity = 10, IsActive = true, ProductGroupId = 1 },
                new Product { Id = 3, Name = "Máy tính 3", SKU = "H0003", StockQuanlity = 10, IsActive = true, ProductGroupId = 2 },
                new Product { Id = 4, Name = "Máy tính 4", SKU = "H0004", StockQuanlity = 10, IsActive = true, ProductGroupId = 2 },
                new Product { Id = 5, Name = "Máy tính 5", SKU = "H0005", StockQuanlity = 10, IsActive = true, ProductGroupId = 3 },
                new Product { Id = 6, Name = "Máy tính 6", SKU = "H0006", StockQuanlity = 10, IsActive = true, ProductGroupId = 3 },
                new Product { Id = 7, Name = "Máy tính 7", SKU = "H0007", StockQuanlity = 10, IsActive = true, ProductGroupId = 1 },
                new Product { Id = 8, Name = "Máy tính 8", SKU = "H0008", StockQuanlity = 10, IsActive = true, ProductGroupId = 3 },
                new Product { Id = 9, Name = "Máy tính 9", SKU = "H0009", StockQuanlity = 10, IsActive = true, ProductGroupId = 3 },
                new Product { Id = 10, Name = "Máy tính 10", SKU = "H0010", StockQuanlity = 10, IsActive = true, ProductGroupId = 1 }
            };

            foreach (Product product in products)
            {
                Product dbproduct = UnitOfWork.Select<Product>().FirstOrDefault(model => model.Name == product.Name);
                if (dbproduct == null)
                {
                    UnitOfWork.Insert(product);
                }
            }

            UnitOfWork.Commit();
            #endregion
        }

        #endregion

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
