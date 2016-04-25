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

            SeedBuildings();
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

        #region Buildings

        private void SeedBuildings()
        {
            #region Building
            Building[] buildings =
            {
                new Building { Id = 1, Name = "Nhà A1", Code = "A1", RoomCount = 100 },
                new Building { Id = 2, Name = "Nhà A2", Code = "A2", RoomCount = 48 },
                new Building { Id = 3, Name = "Nhà A3", Code = "A3", RoomCount = 36 },
            };

            foreach (Building building in buildings)
            {
                Building dbbuilding = UnitOfWork.Select<Building>().FirstOrDefault(model => model.Code == building.Code);
                if (dbbuilding == null)
                {
                    UnitOfWork.Insert(building);
                }
            }

            UnitOfWork.Commit();
            #endregion

            #region ClassRoom
            ClassRoom[] classRooms =
            {
                new ClassRoom { Id = 1, Name = "Phòng học 1", Code = "102A1", Capacity = 10, BuildingId = 1 },
                new ClassRoom { Id = 2, Name = "Phòng học 2", Code = "103A1", Capacity = 20, BuildingId = 1 },
                new ClassRoom { Id = 3, Name = "Phòng học 3", Code = "104A1", Capacity = 30, BuildingId = 1 },
                new ClassRoom { Id = 4, Name = "Phòng học 4", Code = "101A2", Capacity = 40, BuildingId = 2 },
                new ClassRoom { Id = 5, Name = "Phòng học 5", Code = "102A2", Capacity = 50, BuildingId = 2 },
                new ClassRoom { Id = 6, Name = "Phòng học 6", Code = "101A3", Capacity = 60, BuildingId = 3 },
                new ClassRoom { Id = 7, Name = "Phòng học 7", Code = "102A3", Capacity = 70, BuildingId = 3 },
                new ClassRoom { Id = 8, Name = "Phòng học 8", Code = "103A3", Capacity = 80, BuildingId = 3 },
                new ClassRoom { Id = 9, Name = "Phòng học 9", Code = "104A3", Capacity = 90, BuildingId = 3 },
                new ClassRoom { Id = 10, Name = "Phòng học 10", Code = "105A3", Capacity = 100, BuildingId = 3 },
            };

            foreach (ClassRoom classRoom in classRooms)
            {
                ClassRoom dbclassRoom = UnitOfWork.Select<ClassRoom>().FirstOrDefault(model => model.Code == classRoom.Code);
                if (dbclassRoom == null)
                {
                    UnitOfWork.Insert(classRoom);
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
