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
            SeedTeachers();
            SeedSubjects();
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

                #region Manage
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
                #endregion

                #region Student

                #region SubjectRegister

                new Permission { Id = i++, Area = "Student", Controller = "SubjectRegister", Action = "Index" },

                #endregion SubjectRegister
                #endregion

                #region Teacher

                #region Teaching

                new Permission { Id = i++, Area = "Teacher", Controller = "Teaching", Action = "Index" },

                #endregion Teaching
                #endregion

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

            #region Sys_Student
            if (!UnitOfWork.Select<Role>().Any(role => role.Title == "Sys_Student"))
            {
                UnitOfWork.Insert(new Role { Title = "Sys_Student" });
                UnitOfWork.Commit();
            }

            Int32 studentRoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id;
            RolePermission[] studentPermissions = UnitOfWork
                .Select<RolePermission>()
                .Where(rolePermission => rolePermission.RoleId == studentRoleId)
                .ToArray();

            foreach (Permission permission in UnitOfWork.Select<Permission>().Where(p => p.Area == "Student"))
                if (!studentPermissions.Any(rolePermission => rolePermission.PermissionId == permission.Id))
                    UnitOfWork.Insert(new RolePermission
                    {
                        RoleId = studentRoleId,
                        PermissionId = permission.Id
                    });

            UnitOfWork.Commit();
            #endregion

            #region Sys_Teacher
            if (!UnitOfWork.Select<Role>().Any(role => role.Title == "Sys_Teacher"))
            {
                UnitOfWork.Insert(new Role { Title = "Sys_Teacher" });
                UnitOfWork.Commit();
            }

            Int32 teacherRoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Teacher").Id;
            RolePermission[] teacherPermissions = UnitOfWork
                .Select<RolePermission>()
                .Where(rolePermission => rolePermission.RoleId == teacherRoleId)
                .ToArray();

            foreach (Permission permission in UnitOfWork.Select<Permission>().Where(p => p.Area == "Teacher"))
                if (!teacherPermissions.Any(rolePermission => rolePermission.PermissionId == permission.Id))
                    UnitOfWork.Insert(new RolePermission
                    {
                        RoleId = teacherRoleId,
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

        #region Manage

        private void SeedBuildings()
        {
            #region Building
            Building[] buildings =
            {
                new Building { Name = "Tòa nhà B1", Code = "B1", RoomCount = 0 },
                new Building { Name = "Tòa nhà B4", Code = "B4", RoomCount = 0 },
                new Building { Name = "Tòa nhà C6", Code = "C6", RoomCount = 0 },
            };

            foreach (Building building in buildings)
            {
                Building dbbuilding = UnitOfWork.Select<Building>().FirstOrDefault(model => model.Code == building.Code);
                if (dbbuilding == null)
                {
                    UnitOfWork.Insert(building);
                }
                else
                {
                    dbbuilding.Name = building.Name;
                    dbbuilding.RoomCount = building.RoomCount;
                    UnitOfWork.Update(dbbuilding);
                }
            }

            UnitOfWork.Commit();
            #endregion

            #region ClassRoom
            ClassRoom[] classRooms =
            {
                new ClassRoom { Name = "Phòng học 301B4", Code = "301B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 302B4", Code = "302B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 303B4", Code = "303B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 304B4", Code = "304B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 305B4", Code = "305B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 306B4", Code = "306B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },

                new ClassRoom { Name = "Phòng học 401B4", Code = "401B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 402B4", Code = "402B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 403B4", Code = "403B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 404B4", Code = "404B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 405B4", Code = "405B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 406B4", Code = "406B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },

                new ClassRoom { Name = "Phòng học 501B4", Code = "501B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 502B4", Code = "502B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 503B4", Code = "503B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 504B4", Code = "504B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 505B4", Code = "505B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 506B4", Code = "506B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },

                new ClassRoom { Name = "Phòng học 601B4", Code = "601B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 602B4", Code = "602B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 603B4", Code = "603B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 604B4", Code = "604B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 605B4", Code = "605B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },
                new ClassRoom { Name = "Phòng học 606B4", Code = "606B4", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B4").Id },


                new ClassRoom { Name = "Phòng học 301B1", Code = "301B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 302B1", Code = "302B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 303B1", Code = "303B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 304B1", Code = "304B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 305B1", Code = "305B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 306B1", Code = "306B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 307B1", Code = "307B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 308B1", Code = "308B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 309B1", Code = "309B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 310B1", Code = "310B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 311B1", Code = "311B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 312B1", Code = "312B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 313B1", Code = "313B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },
                new ClassRoom { Name = "Phòng học 314B1", Code = "314B1", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "B1").Id },


                new ClassRoom { Name = "Phòng học 301C6", Code = "301C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 302C6", Code = "302C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 303C6", Code = "303C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 304C6", Code = "304C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 305C6", Code = "305C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 306C6", Code = "306C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },

                new ClassRoom { Name = "Phòng học 401C6", Code = "401C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 402C6", Code = "402C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 403C6", Code = "403C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 404C6", Code = "404C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 405C6", Code = "405C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 406C6", Code = "406C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },

                new ClassRoom { Name = "Phòng học 501C6", Code = "501C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 502C6", Code = "502C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 503C6", Code = "503C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 504C6", Code = "504C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 505C6", Code = "505C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },
                new ClassRoom { Name = "Phòng học 506C6", Code = "506C6", Capacity = 40, BuildingId = UnitOfWork.Select<Building>().Single(dep => dep.Code == "C6").Id },

            };

            foreach (ClassRoom classRoom in classRooms)
            {
                ClassRoom dbclassRoom = UnitOfWork.Select<ClassRoom>().FirstOrDefault(model => model.Code == classRoom.Code);
                if (dbclassRoom == null)
                {
                    UnitOfWork.Insert(classRoom);
                }
                else
                {
                    dbclassRoom.Name = classRoom.Name;
                    dbclassRoom.Capacity = classRoom.Capacity;
                    dbclassRoom.BuildingId = classRoom.BuildingId;
                    UnitOfWork.Update(dbclassRoom);
                }
            }

            UnitOfWork.Commit();


            // update RoomCount
            foreach (Building building in buildings)
            {
                Building dbbuilding = UnitOfWork.Select<Building>().FirstOrDefault(model => model.Code == building.Code);
                if (dbbuilding != null)
                {
                    dbbuilding.RoomCount = dbbuilding.ClassRooms.Count();
                    UnitOfWork.Update(dbbuilding);
                }
            }
            UnitOfWork.Commit();

            #endregion
        }

        private void SeedTeachers()
        {
            #region Faculty
            Faculty[] faculties =
            {
                new Faculty {
                    Abbreviation = "KH&KTMT",
                    Name = "Khoa học và Kỹ thuật máy tính",
                    Email = "welcome@cse.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8.647.256 - Ext: 5847",
                    FaxNumber = "(84.8) 8.645.137",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
                new Faculty {
                    Abbreviation = "ĐĐT",
                    Name = "Điện - Điện tử",
                    Email = "vpk@dee.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8 657 296 – Ext: 5746",
                    FaxNumber = "(84.8) 8 645 796",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
            };

            foreach (Faculty faculty in faculties)
            {
                Faculty dbfaculty = UnitOfWork.Select<Faculty>().FirstOrDefault(model => model.Abbreviation == faculty.Abbreviation);
                if (dbfaculty == null)
                {
                    UnitOfWork.Insert(faculty);
                }
                else
                {
                    dbfaculty.Name = faculty.Name;
                    dbfaculty.Email = faculty.Email;
                    dbfaculty.PhoneNumber = faculty.PhoneNumber;
                    dbfaculty.FaxNumber = faculty.FaxNumber;
                    dbfaculty.Address = faculty.Address;
                    UnitOfWork.Update(dbfaculty);
                }
            }

            UnitOfWork.Commit();
            #endregion

            #region Department
            Department[] departments =
            {
                new Department {
                    Name = "Khoa học máy tính",
                    Email = "welcome@cse.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8.647.256 - Ext: 5847",
                    FaxNumber = "(84.8) 8.645.137",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM",
                    FacultyId = UnitOfWork.Select<Faculty>().Single(model => model.Abbreviation == "KH&KTMT").Id },
                new Department {
                    Name = "Kỹ thuật Máy tính",
                    Email = "welcome@cse.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8.647.256 - Ext: 5847",
                    FaxNumber = "(84.8) 8.645.137",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM",
                    FacultyId = UnitOfWork.Select<Faculty>().Single(model => model.Abbreviation == "KH&KTMT").Id },
                new Department {
                    Name = "Hệ thống Thông tin",
                    Email = "welcome@cse.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8.647.256 - Ext: 5847",
                    FaxNumber = "(84.8) 8.645.137",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM",
                    FacultyId = UnitOfWork.Select<Faculty>().Single(model => model.Abbreviation == "KH&KTMT").Id },
                new Department {
                    Name = "Công nghệ Phần mềm",
                    Email = "welcome@cse.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8.647.256 - Ext: 5847",
                    FaxNumber = "(84.8) 8.645.137",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM",
                    FacultyId = UnitOfWork.Select<Faculty>().Single(model => model.Abbreviation == "KH&KTMT").Id },
                new Department {
                    Name = "Hệ thống và Mạng Máy tính",
                    Email = "welcome@cse.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8.647.256 - Ext: 5847",
                    FaxNumber = "(84.8) 8.645.137",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM",
                    FacultyId = UnitOfWork.Select<Faculty>().Single(model => model.Abbreviation == "KH&KTMT").Id },


                new Department {
                    Name = "Cơ sở kỹ thuật Điện",
                    Email = "vpk@dee.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8 657 296 – Ext: 5746",
                    FaxNumber = "(84.8) 8 645 796",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM",
                    FacultyId = UnitOfWork.Select<Faculty>().Single(model => model.Abbreviation == "ĐĐT").Id },
                new Department {
                    Name = "Điện tử",
                    Email = "vpk@dee.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8 657 296 – Ext: 5746",
                    FaxNumber = "(84.8) 8 645 796",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM",
                    FacultyId = UnitOfWork.Select<Faculty>().Single(model => model.Abbreviation == "ĐĐT").Id },
                new Department {
                    Name = "Viễn thông",
                    Email = "vpk@dee.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8 657 296 – Ext: 5746",
                    FaxNumber = "(84.8) 8 645 796",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM",
                    FacultyId = UnitOfWork.Select<Faculty>().Single(model => model.Abbreviation == "ĐĐT").Id },
                new Department {
                    Name = "Điều khiển tự động",
                    Email = "vpk@dee.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8 657 296 – Ext: 5746",
                    FaxNumber = "(84.8) 8 645 796",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM",
                    FacultyId = UnitOfWork.Select<Faculty>().Single(model => model.Abbreviation == "ĐĐT").Id },
                new Department {
                    Name = "Thiết bị điện",
                    Email = "vpk@dee.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8 657 296 – Ext: 5746",
                    FaxNumber = "(84.8) 8 645 796",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM",
                    FacultyId = UnitOfWork.Select<Faculty>().Single(model => model.Abbreviation == "ĐĐT").Id },
                new Department {
                    Name = "Hệ thống điện",
                    Email = "vpk@dee.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8 657 296 – Ext: 5746",
                    FaxNumber = "(84.8) 8 645 796",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM",
                    FacultyId = UnitOfWork.Select<Faculty>().Single(model => model.Abbreviation == "ĐĐT").Id },
                new Department {
                    Name = "Cung cấp điện",
                    Email = "vpk@dee.hcmut.edu.vn",
                    PhoneNumber = "(84.8) 8 657 296 – Ext: 5746",
                    FaxNumber = "(84.8) 8 645 796",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM",
                    FacultyId = UnitOfWork.Select<Faculty>().Single(model => model.Abbreviation == "ĐĐT").Id },
            };

            foreach (Department department in departments)
            {
                Department dbdepartment = UnitOfWork.Select<Department>().FirstOrDefault(model => model.Name == department.Name);
                if (dbdepartment == null)
                {
                    UnitOfWork.Insert(department);
                }
                else
                {
                    dbdepartment.Email = department.Email;
                    dbdepartment.PhoneNumber = department.PhoneNumber;
                    dbdepartment.FaxNumber = department.FaxNumber;
                    dbdepartment.Address = department.Address;
                    dbdepartment.FacultyId = department.FacultyId;
                    UnitOfWork.Update(dbdepartment);
                }
            }

            UnitOfWork.Commit();
            #endregion

            #region StaffAccount
            Account[] accounts =
            {
                new Account
                {
                    Username = "12920",//	Nguyễn Thanh Bình
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "binhnt@cse.hcmut.edu.vn",
                    IsLocked = false,
                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Teacher").Id
                },
                new Account
                {
                    Username = "02109",//	Ng.Văn Minh	Mẫn
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "mannvm@cse.hcmut.edu.vn",
                    IsLocked = false,
                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Teacher").Id
                },
                new Account
                {
                    Username = "13045",//	Huỳnh Tường	Nguyên
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "nguyenht@cse.hcmut.edu.vn",
                    IsLocked = false,
                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Teacher").Id
                },
                new Account
                {
                    Username = "01733",//	Nguyễn Hứa	Phùng
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "phungnh@cse.hcmut.edu.vn",
                    IsLocked = false,
                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Teacher").Id
                },
                new Account
                {
                    Username = "01616",//	Cao Hoàng	Trụ
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "tru@cse.hcmut.edu.vn",
                    IsLocked = false,
                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Teacher").Id
                },
                new Account
                {
                    Username = "00163",//	Phan Thị	Tươi
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "tuoi@cse.hcmut.edu.vn",
                    IsLocked = false,
                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Teacher").Id
                },
                new Account
                {
                    Username = "01995",//	Lê Thành	Sách
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "ltsach@cse.hcmut.edu.vn",
                    IsLocked = false,
                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Teacher").Id
                },
                new Account
                {
                    Username = "12715",//	Trần Giang	Sơn
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "sontg@cse.hcmut.edu.vn",
                    IsLocked = false,
                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Teacher").Id
                },
                new Account
                {
                    Username = "13444",//	Vương Bá	Thịnh
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "thinhvb@cse.hcmut.edu.vn",
                    IsLocked = false,
                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Teacher").Id
                },
                new Account
                {
                    Username = "00529",//	Dương Tuấn	Anh
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "anhdt@cse.hcmut.edu.vn",
                    IsLocked = false,
                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Teacher").Id
                },
                new Account
                {
                    Username = "13282",//	Võ Thanh	Hùng
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "hungvt@cse.hcmut.edu.vn",
                    IsLocked = false,
                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Teacher").Id
                },
            };

            foreach (Account account in accounts)
            {
                Account dbAccount = UnitOfWork.Select<Account>().FirstOrDefault(model => model.Username == account.Username);
                if (dbAccount == null)
                {
                    UnitOfWork.Insert(account);
                }
                else
                {
                    dbAccount.IsLocked = account.IsLocked;
                    dbAccount.Passhash = account.Passhash;
                    dbAccount.Email = account.Email;
                    UnitOfWork.Update(dbAccount);
                }
            }

            UnitOfWork.Commit();
            #endregion

            #region Staff
            Staff[] staffs =
            {
                new Staff {
                    Code = "12920",
                    Name = "Nguyễn Thanh Bình",
                    Gender = "Nam",
                    DateOfBirth = new DateTime(1950, 1, 1),
                    PlaceOfBirth = "BK",
                    DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id,
                    AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "12920").Id,
                    PhoneNumber = "09123456789",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
                new Staff {
                    Code = "02109",
                    Name = "Nguyễn Văn Minh Mẫn",
                    Gender = "Nam",
                    DateOfBirth = new DateTime(1950, 1, 1),
                    PlaceOfBirth = "BK",
                    DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id,
                    AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "02109").Id,
                    PhoneNumber = "09123456789",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
                new Staff {
                    Code = "13045",
                    Name = "Huỳnh Tường Nguyên",
                    Gender = "Nam",
                    DateOfBirth = new DateTime(1950, 1, 1),
                    PlaceOfBirth = "BK",
                    DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id,
                    AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "13045").Id,
                    PhoneNumber = "09123456789",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
                new Staff {
                    Code = "01733",
                    Name = "Nguyễn Hứa Phùng",
                    Gender = "Nam",
                    DateOfBirth = new DateTime(1950, 1, 1),
                    PlaceOfBirth = "BK",
                    DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id,
                    AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "01733").Id,
                    PhoneNumber = "09123456789",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
                new Staff {
                    Code = "01616",
                    Name = "Cao Hoàng Trụ",
                    Gender = "Nam",
                    DateOfBirth = new DateTime(1950, 1, 1),
                    PlaceOfBirth = "BK",
                    DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id,
                    AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "01616").Id,
                    PhoneNumber = "09123456789",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
                new Staff {
                    Code = "00163",
                    Name = "Phan Thị Tươi",
                    Gender = "Nữ",
                    DateOfBirth = new DateTime(1950, 1, 1),
                    PlaceOfBirth = "BK",
                    DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id,
                    AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "00163").Id,
                    PhoneNumber = "09123456789",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
                new Staff {
                    Code = "01995",
                    Name = "Lê Thành Sách",
                    Gender = "Nam",
                    DateOfBirth = new DateTime(1950, 1, 1),
                    PlaceOfBirth = "BK",
                    DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id,
                    AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "01995").Id,
                    PhoneNumber = "09123456789",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
                new Staff {
                    Code = "12715",
                    Name = "Trần Giang Sơn",
                    Gender = "Nam",
                    DateOfBirth = new DateTime(1950, 1, 1),
                    PlaceOfBirth = "BK",
                    DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id,
                    AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "12715").Id,
                    PhoneNumber = "09123456789",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
                new Staff {
                    Code = "13444",
                    Name = "Vương Bá Thịnh",
                    Gender = "Nam",
                    DateOfBirth = new DateTime(1950, 1, 1),
                    PlaceOfBirth = "BK",
                    DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id,
                    AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "13444").Id,
                    PhoneNumber = "09123456789",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
                new Staff {
                    Code = "00529",
                    Name = "Dương Tuấn Anh",
                    Gender = "Nam",
                    DateOfBirth = new DateTime(1950, 1, 1),
                    PlaceOfBirth = "BK",
                    DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id,
                    AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "00529").Id,
                    PhoneNumber = "09123456789",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
                new Staff {
                    Code = "13282",
                    Name = "Võ Thanh Hùng",
                    Gender = "Nam",
                    DateOfBirth = new DateTime(1950, 1, 1),
                    PlaceOfBirth = "BK",
                    DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id,
                    AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "13282").Id,
                    PhoneNumber = "09123456789",
                    Address = "A3 – 268 Lý Thường Kiệt, Q. 10, TP. HCM" },
            };

            foreach (Staff staff in staffs)
            {
                Staff dbstaff = UnitOfWork.Select<Staff>().FirstOrDefault(model => model.Code == staff.Code);
                if (dbstaff == null)
                {
                    UnitOfWork.Insert(staff);
                }
                else
                {
                    dbstaff.Name = staff.Name;
                    dbstaff.Gender = staff.Gender;
                    dbstaff.DateOfBirth = staff.DateOfBirth;
                    dbstaff.PlaceOfBirth = staff.PlaceOfBirth;
                    dbstaff.DepartmentId = staff.DepartmentId;
                    dbstaff.AccountId = staff.AccountId;
                    dbstaff.PhoneNumber = staff.PhoneNumber;
                    dbstaff.Address = staff.Address;
                    UnitOfWork.Update(dbstaff);
                }
            }

            UnitOfWork.Commit();
            #endregion

        }

        private void SeedSubjects()
        {
            #region Subject
            Subject[] subjects =
            {
                new Subject { Code = "054001", Name = "Trí tuệ nhân tạo", NameEn = "Artificial Intelligence", NumberOfCredits = 4, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "054002", Name = "Mạng máy tính 1", NameEn = "Computer Networks 1", NumberOfCredits = 4, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "054003", Name = "Nguyên lý Ngôn ngữ lập trình", NameEn = "Principles of Programming Languages", NumberOfCredits = 4, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "054004", Name = "Phân tích thiết kế giải thuật", NameEn = "Algorithms Analysis and Design", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055001", Name = "Giải thuật nâng cao", NameEn = "Advanced Algorithms", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055002", Name = "Hệ cơ sở dữ liệu nâng cao", NameEn = "Advanced Database Systems", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055003", Name = "Kiến trúc máy tính nâng cao", NameEn = "Advanced Computer Architecture", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055004", Name = "Khai phá dữ liệu", NameEn = "Data mining", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055005", Name = "Hệ thống thông tin quản lý", NameEn = "Management Information Systems", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055006", Name = "Cơ sở tri thức", NameEn = "Knowledge-Based Systems", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055007", Name = "Hệ thống thông minh", NameEn = "Intelligent Systems", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055008", Name = "Lập trình logic và ràng buộc", NameEn = "Logic Programming and Constraints", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055009", Name = "Xử lý ảnh số và video nâng cao", NameEn = "Advanced Digital Image and Video Processing", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055010", Name = "Thiết kế phần mềm hướng đối tượng", NameEn = "Object-Oriented Software Design", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055011", Name = "Các giải thuật tối ưu dùng trong công nghiệp", NameEn = "Optimization Algorithms in Production Management", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055012", Name = "Hệ hỗ trợ quyết định", NameEn = "Decision Support Systems", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055013", Name = "Thống kê đại số tính toán và ứng dụng", NameEn = "Computational Algebraic Statistics", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055014", Name = "Tính toán hệ thống khả cấu hình", NameEn = "Reconfigurable Computing", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055016", Name = "Xử lý ngôn ngữ tự nhiên", NameEn = "Natural Language Processing", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055017", Name = "Đồ họa máy tính nâng cao", NameEn = "Advanced Computer Graphics", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055018", Name = "Phương pháp thiết kế vi mạch", NameEn = "Hardware Design Methodologies", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055019", Name = "Phân tích chương trình", NameEn = "Program Analysis", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055020", Name = "Hệ thống nhúng", NameEn = "Embedded Systems", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055022", Name = "Kiểm tra chương trình", NameEn = "Program Verification", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055023", Name = "Hệ thời gian thực", NameEn = "Management Information Systems", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055024", Name = "Hệ phân bố", NameEn = "Distributed Systems", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055026", Name = "Tính toán song song", NameEn = "Parallel Computing", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055027", Name = "Đánh giá hiệu suất hệ thống", NameEn = "Systems Performance and Evaluation", NumberOfCredits = 2, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055028", Name = "Tổng quan về tính toán khoa học", NameEn = "Introduction to Scientific Computing", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055029", Name = "Những chủ đề nâng cao về tính toán hiệu năng cao", NameEn = "Selected Topics in High Performance Computing", NumberOfCredits = 2, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055030", Name = "Khai phá dữ liệu siêu lớn", NameEn = "Mining massive datasets", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055031", Name = "Những chủ đề nâng cao về khoa học tính toán", NameEn = "Selected Topics in Scientific Computing", NumberOfCredits = 2, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055032", Name = "Dữ liệu lớn", NameEn = "Big Data", NumberOfCredits = 3, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055034", Name = "Nền tảng toán học cho tính toán hiệu năng cao", NameEn = "Mathematical Foundation For High Performance Computing", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055040", Name = "Mã hóa", NameEn = "Cryptography", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055042", Name = "Bảo mật cơ sở dữ liệu", NameEn = "Database Sercurity", NumberOfCredits = 3, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055043", Name = "Bảo mật hệ thống thông tin hiện đại", NameEn = "Security in Modern Information Systems", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055044", Name = "Bảo mật trên thiết bị di động", NameEn = "Mobile Devices Security", NumberOfCredits = 3, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055046", Name = "Trực quan hóa trong bảo mật", NameEn = "Security Visualization", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055047", Name = "Bảo mật sinh trắc học", NameEn = "Biometric Security", NumberOfCredits = 3, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055048", Name = "Bảo mật tính riêng tư trong khai phá dữ liệu", NameEn = "Privacy-Preserving Data Mining", NumberOfCredits = 3, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055049", Name = "Bảo mật trên điện toán đám mây", NameEn = "Security In Cloud Computing", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055050", Name = "Bằng chứng số", NameEn = "Digital Forensics", NumberOfCredits = 3, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055055", Name = "Bảo mật thông tin cho nhà quản lý", NameEn = "Information security for managers", NumberOfCredits = 3, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055068", Name = "Lập trình nâng cao", NameEn = "Advanced Programming", NumberOfCredits = 3, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055069", Name = "Nhận dạng mẫu và học máy", NameEn = "Pattern Recognition And Machine Learning", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055070", Name = "Trực quan hóa thông tin và dữ liệu", NameEn = "Data and information visualization", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055071", Name = "Tương tác người máy", NameEn = "Human-computer interaction", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055072", Name = "Kiến trúc phần mềm", NameEn = "Software Architecture", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055073", Name = "Đặc tả yêu cầu phần mềm", NameEn = "Requirements engineering", NumberOfCredits = 3, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055074", Name = "Mô hình hóa phần mềm", NameEn = "Conceptual modeling", NumberOfCredits = 3, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055075", Name = "Thiết kế phần mềm theo mẫu", NameEn = "Design patterns", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055076", Name = "Điện toán đám mây", NameEn = "Cloud Computing", NumberOfCredits = 3, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055077", Name = "Công nghệ phần mềm thế hệ mới", NameEn = "New Generation Software Engineering", NumberOfCredits = 3, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055078", Name = "Mạng máy tính nâng cao", NameEn = "Advanced Computer Networks", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "055079", Name = "An ninh mạng", NameEn = "Network Security", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "056001", Name = "Luận văn thạc sĩ", NameEn = "Thesis", NumberOfCredits = 15, NumberOfPeriods = 0, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "125900", Name = "Triết học", NameEn = "Philosophy", NumberOfCredits = 3, NumberOfPeriods = 45, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "155900", Name = "Anh văn", NameEn = "English", NumberOfCredits = 0, NumberOfPeriods = 100, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
                new Subject { Code = "505904", Name = "Phương pháp nghiên cứu khoa học", NameEn = "Methodology of Scientific Research", NumberOfCredits = 2, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
            };

            foreach (Subject subject in subjects)
            {
                Subject dbsubject = UnitOfWork.Select<Subject>().FirstOrDefault(model => model.Code == subject.Code);
                if (dbsubject == null)
                {
                    UnitOfWork.Insert(subject);
                }
                else
                {
                    dbsubject.Name = subject.Name;
                    dbsubject.NameEn = subject.NameEn;
                    dbsubject.NumberOfCredits = subject.NumberOfCredits;
                    dbsubject.NumberOfPeriods = subject.NumberOfPeriods;
                    dbsubject.DepartmentId = subject.DepartmentId;
                    UnitOfWork.Update(dbsubject);
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





























































