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
            Permission[] permissions =
            {
                #region Administration
                //1
                new Permission { Id = 1, Area = "Administration", Controller = "Accounts", Action = "Index" },
                new Permission { Id = 2, Area = "Administration", Controller = "Accounts", Action = "Create" },
                new Permission { Id = 3, Area = "Administration", Controller = "Accounts", Action = "Details" },
                new Permission { Id = 4, Area = "Administration", Controller = "Accounts", Action = "Edit" },
                new Permission { Id = 5, Area = "Administration", Controller = "Accounts", Action = "Delete" },
                //2
                new Permission { Id = 6, Area = "Administration", Controller = "Roles", Action = "Index" },
                new Permission { Id = 7, Area = "Administration", Controller = "Roles", Action = "Create" },
                new Permission { Id = 8, Area = "Administration", Controller = "Roles", Action = "Details" },
                new Permission { Id = 9, Area = "Administration", Controller = "Roles", Action = "Edit" },
                new Permission { Id = 10, Area = "Administration", Controller = "Roles", Action = "Delete" },
                //3
                new Permission { Id = 11, Area = "Administration", Controller = "SystemSettings", Action = "Index" },
                new Permission { Id = 12, Area = "Administration", Controller = "SystemSettings", Action = "Create" },
                new Permission { Id = 13, Area = "Administration", Controller = "SystemSettings", Action = "Details" },
                new Permission { Id = 14, Area = "Administration", Controller = "SystemSettings", Action = "Edit" },
                new Permission { Id = 15, Area = "Administration", Controller = "SystemSettings", Action = "Delete" },

                #endregion Administration

                #region Products
                //4
                new Permission { Id = 16, Area = "Manage", Controller = "Products", Action = "Index" },
                new Permission { Id = 17, Area = "Manage", Controller = "Products", Action = "Create" },
                new Permission { Id = 18, Area = "Manage", Controller = "Products", Action = "Details" },
                new Permission { Id = 19, Area = "Manage", Controller = "Products", Action = "Edit" },
                new Permission { Id = 20, Area = "Manage", Controller = "Products", Action = "Delete" },
                //5
                new Permission { Id = 21, Area = "Manage", Controller = "ProductGroups", Action = "Index" },
                new Permission { Id = 22, Area = "Manage", Controller = "ProductGroups", Action = "Create" },
                new Permission { Id = 23, Area = "Manage", Controller = "ProductGroups", Action = "Details" },
                new Permission { Id = 24, Area = "Manage", Controller = "ProductGroups", Action = "Edit" },
                new Permission { Id = 25, Area = "Manage", Controller = "ProductGroups", Action = "Delete" },

                #endregion Products

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
        }

        private void SeedAccounts()
        {
            Account[] accounts =
            {
                new Account
                {
                    Name = "Administrator",
                    Username = "admin",
                    Passhash = "$2a$13$yTgLCqGqgH.oHmfboFCjyuVUy5SJ2nlyckPFEZRJQrMTZWN.f1Afq", // Admin123?
                    Email = "admin@admins.com",
                    Position = "Administrator",
                    Phone = "0123456789",
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
