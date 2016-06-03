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
            SeedCurriculums();
            SeedStudents();
            SeedStudies();
        }

        #region Administration

        private void SeedPermissions()
        {
            #region Permission
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
                new Permission { Id = i++, Area = "Manage", Controller = "Curriculums", Action = "Details" },

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
                new Permission { Id = i++, Area = "Student", Controller = "SubjectRegister", Action = "Register" },
                new Permission { Id = i++, Area = "Student", Controller = "SubjectRegister", Action = "Delete" },

                #endregion SubjectRegister
                #endregion

                #region Teacher

                #region Teaching

                new Permission { Id = i++, Area = "Teacher", Controller = "Teaching", Action = "Index" },
                new Permission { Id = i++, Area = "Teacher", Controller = "Teaching", Action = "Details" },
                new Permission { Id = i++, Area = "Teacher", Controller = "Teaching", Action = "UpdateScore" },

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
            UnitOfWork.Commit();

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

            #endregion
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

            foreach (Permission permission in UnitOfWork.Select<Permission>().Where(p => p.Area == "Administration" || p.Area == "Manage"))
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
            #region Account
            Account[] accounts =
            {
                new Account
                {
                    Username = "admin",
                    //Passhash = "$2a$13$yTgLCqGqgH.oHmfboFCjyuVUy5SJ2nlyckPFEZRJQrMTZWN.f1Afq", // Admin123?
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "admin@admins.com",
                    IsLocked = false,

                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Admin").Id
                },
                new Account
                {
                    Username = "manage",
                    //Passhash = "$2a$13$yTgLCqGqgH.oHmfboFCjyuVUy5SJ2nlyckPFEZRJQrMTZWN.f1Afq", // Admin123?
                    Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS", // 123456
                    Email = "manage@manages.com",
                    IsLocked = false,

                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Manage").Id
                },
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

            #endregion
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
                new Subject { Code = "505900", Name = "Phương pháp nghiên cứu khoa học", NameEn = "Methodology of Scientific Research", NumberOfCredits = 2, NumberOfPeriods = 30, DepartmentId = UnitOfWork.Select<Department>().Single(dep => dep.Name == "Khoa học máy tính").Id },
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

            #region PreSubject

            #endregion
        }

        private void SeedStudents()
        {
            #region Course
            Course[] courses =
            {
                new Course { Code = "MCS2013", Name = "Cao học Khoa học máy tính K2013", StartDate = new DateTime(2014, 9, 1), EndDate = new DateTime(2017, 9, 1) , FacultyId = UnitOfWork.Select<Faculty>().Single(dep => dep.Abbreviation == "KH&KTMT").Id },
                new Course { Code = "MCS2014", Name = "Cao học Khoa học máy tính K2014", StartDate = new DateTime(2014, 9, 1), EndDate = new DateTime(2017, 9, 1) , FacultyId = UnitOfWork.Select<Faculty>().Single(dep => dep.Abbreviation == "KH&KTMT").Id },
                new Course { Code = "MCS2015", Name = "Cao học Khoa học máy tính K2015", StartDate = new DateTime(2015, 9, 1), EndDate = new DateTime(2018, 9, 1) , FacultyId = UnitOfWork.Select<Faculty>().Single(dep => dep.Abbreviation == "KH&KTMT").Id },
                new Course { Code = "MIS2014", Name = "Cao học Hệ thống thông tin K2014", StartDate = new DateTime(2014, 9, 1), EndDate = new DateTime(2017, 9, 1) , FacultyId = UnitOfWork.Select<Faculty>().Single(dep => dep.Abbreviation == "KH&KTMT").Id },
                new Course { Code = "MIS2015", Name = "Cao học Hệ thống thông tin K2015", StartDate = new DateTime(2015, 9, 1), EndDate = new DateTime(2018, 9, 1) , FacultyId = UnitOfWork.Select<Faculty>().Single(dep => dep.Abbreviation == "KH&KTMT").Id },
            };

            foreach (Course course in courses)
            {
                Course dbcourse = UnitOfWork.Select<Course>().FirstOrDefault(model => model.Code == course.Code);
                if (dbcourse == null)
                {
                    UnitOfWork.Insert(course);
                }
                else
                {
                    dbcourse.Name = course.Name;
                    dbcourse.StartDate = course.StartDate;
                    dbcourse.EndDate = course.EndDate;
                    dbcourse.FacultyId = course.FacultyId;
                    UnitOfWork.Update(dbcourse);
                }
            }

            UnitOfWork.Commit();
            #endregion

            #region StudentClass
            StudentClass[] studentClasses =
            {
                new StudentClass { Abbreviation = "MCS2013/1", Name = "Cao học Khoa học máy tính K2013 Đợt 1", CourseId = UnitOfWork.Select<Course>().Single(c => c.Code == "MCS2013").Id, StaffId = UnitOfWork.Select<Staff>().Single(c => c.Code == "00529").Id, CurriculumId = UnitOfWork.Select<Curriculum>().Single(c => c.Name == "MCS 2014 By Course").Id },
                new StudentClass { Abbreviation = "MCS2013/2", Name = "Cao học Khoa học máy tính K2013 Đợt 2", CourseId = UnitOfWork.Select<Course>().Single(c => c.Code == "MCS2013").Id, StaffId = UnitOfWork.Select<Staff>().Single(c => c.Code == "01995").Id, CurriculumId = UnitOfWork.Select<Curriculum>().Single(c => c.Name == "MCS 2014 By Course").Id },
                new StudentClass { Abbreviation = "MCS2014/1", Name = "Cao học Khoa học máy tính K2014 Đợt 1", CourseId = UnitOfWork.Select<Course>().Single(c => c.Code == "MCS2014").Id, StaffId = UnitOfWork.Select<Staff>().Single(c => c.Code == "00163").Id, CurriculumId = UnitOfWork.Select<Curriculum>().Single(c => c.Name == "MCS 2014 By Course").Id },
                new StudentClass { Abbreviation = "MCS2014/2", Name = "Cao học Khoa học máy tính K2014 Đợt 2", CourseId = UnitOfWork.Select<Course>().Single(c => c.Code == "MCS2014").Id, StaffId = UnitOfWork.Select<Staff>().Single(c => c.Code == "01616").Id, CurriculumId = UnitOfWork.Select<Curriculum>().Single(c => c.Name == "MCS 2014 By Course").Id },
                new StudentClass { Abbreviation = "MCS2015/1", Name = "Cao học Khoa học máy tính K2015 Đợt 1", CourseId = UnitOfWork.Select<Course>().Single(c => c.Code == "MCS2015").Id, StaffId = UnitOfWork.Select<Staff>().Single(c => c.Code == "01733").Id, CurriculumId = UnitOfWork.Select<Curriculum>().Single(c => c.Name == "MCS 2014 By Course").Id },
                new StudentClass { Abbreviation = "MCS2015/2", Name = "Cao học Khoa học máy tính K2015 Đợt 2", CourseId = UnitOfWork.Select<Course>().Single(c => c.Code == "MCS2015").Id, StaffId = UnitOfWork.Select<Staff>().Single(c => c.Code == "13045").Id, CurriculumId = UnitOfWork.Select<Curriculum>().Single(c => c.Name == "MCS 2014 By Course").Id },
                new StudentClass { Abbreviation = "MIS2014/1", Name = "Cao học Hệ thống thông tin K2014 Đợt 1", CourseId = UnitOfWork.Select<Course>().Single(c => c.Code == "MIS2014").Id, StaffId = UnitOfWork.Select<Staff>().Single(c => c.Code == "02109").Id, CurriculumId = UnitOfWork.Select<Curriculum>().Single(c => c.Name == "MCS 2014 By Course").Id },
                new StudentClass { Abbreviation = "MIS2014/2", Name = "Cao học Hệ thống thông tin K2014 Đợt 2", CourseId = UnitOfWork.Select<Course>().Single(c => c.Code == "MIS2014").Id, StaffId = UnitOfWork.Select<Staff>().Single(c => c.Code == "13282").Id, CurriculumId = UnitOfWork.Select<Curriculum>().Single(c => c.Name == "MCS 2014 By Course").Id },
                new StudentClass { Abbreviation = "MIS2015/1", Name = "Cao học Hệ thống thông tin K2015 Đợt 1", CourseId = UnitOfWork.Select<Course>().Single(c => c.Code == "MIS2015").Id, StaffId = UnitOfWork.Select<Staff>().Single(c => c.Code == "13444").Id, CurriculumId = UnitOfWork.Select<Curriculum>().Single(c => c.Name == "MCS 2014 By Course").Id },
                new StudentClass { Abbreviation = "MIS2015/2", Name = "Cao học Hệ thống thông tin K2015 Đợt 2", CourseId = UnitOfWork.Select<Course>().Single(c => c.Code == "MIS2015").Id, StaffId = UnitOfWork.Select<Staff>().Single(c => c.Code == "12920").Id, CurriculumId = UnitOfWork.Select<Curriculum>().Single(c => c.Name == "MCS 2014 By Course").Id },
            };

            foreach (StudentClass studentClass in studentClasses)
            {
                StudentClass dbstudentClass = UnitOfWork.Select<StudentClass>().FirstOrDefault(model => model.Abbreviation == studentClass.Abbreviation);
                if (dbstudentClass == null)
                {
                    UnitOfWork.Insert(studentClass);
                }
                else
                {
                    dbstudentClass.Name = studentClass.Name;
                    dbstudentClass.CourseId = studentClass.CourseId;
                    dbstudentClass.StaffId = studentClass.StaffId;
                    UnitOfWork.Update(dbstudentClass);
                }
            }

            UnitOfWork.Commit();
            #endregion

            #region StudentAccount
            Account[] accounts =
            {
                new Account { Username = "13073035", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "tranthesi@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },

                new Account { Username = "1570010", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenngocphien@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570202", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "lamtuananh@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570203", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "ngodinhdung@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570204", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "thaibinhduong@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570205", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "huynhanhduy@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570208", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "quachdinhhoang@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570209", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "diephung@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570210", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "dangdanhhuu@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570212", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "tranvinhkhai@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570213", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "phamminhkhue@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570214", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenvankien@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570215", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenchauky@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570216", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenkimlanh@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570217", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenvanlinh@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570220", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenvanluan@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570222", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenngocphuong@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570223", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenthanhphuong@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570225", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "luuhuuquyet@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570233", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "daothithutrang@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570234", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "phamthanhtri@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570235", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "lucminhtuan@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570236", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "trannhattuan@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570613", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenanhhuy@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570733", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "lamtruongan@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570734", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenhaivinhcuong@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570735", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "phamhoangduyduc@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570737", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenvohuyhoang@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570738", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "vokhanhhuy@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570739", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "tranthikimkhanh@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570740", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenhoangminh@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570741", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenlequangnhat@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570742", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "phanthanhnhuan@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570743", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "buithanhphong@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570744", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenminhquan@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570745", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "trinhbaoquan@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570746", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "vonguyenthanh@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570747", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "tranhungthuan@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570748", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenngoctien@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570749", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenvantien@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570750", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyentrantoan@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570751", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenxuantrai@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570752", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenminhtriet@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "1570753", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyendanghoangtuan@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },

                new Account { Username = "7140020", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "huynhvang@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140225", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenvanduong@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140226", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "lenguyenkhanhduy@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140230", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenthanhhai@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140231", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "buiduchieu@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140235", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "bienleanhhung@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140237", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "dangquochuynh@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140240", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "vominhkhai@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140258", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "phamminhthien@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140265", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "vothaituyen@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140820", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "aumauduong@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140821", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "doanxuanduy@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140822", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenvietdang@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140824", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "lethanhhoa@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140831", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "trancaonguyen@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140832", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "luunguyenhoangquan@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140839", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenkhactrung@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140844", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "trannguyenvo@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140845", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "dangngocvu@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7140846", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "hoangvannhatvu@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7141161", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "nguyenngoctuyen@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7141248", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "trannamphong@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
                new Account { Username = "7141249", Passhash = "$2a$13$MMRvGGPtpS4/5h6DmL6JxueP0.JHI87eZPoRR0UwzrP50AMCqCBRS" /* 123456 */, Email = "levan@gmail.com", IsLocked = false, RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Student").Id },
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

            #region Student
            Student[] students =
            {
                new Student { Code = "13073035", Name = "Trần Thế Sĩ", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01213073035" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "13073035").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2013/2").Id },

                new Student { Code = "1570010", Name = "Nguyễn Ngọc Phiên", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570010" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570010").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570202", Name = "Lâm Tuấn Anh", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570202" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570202").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570203", Name = "Ngô Đình Dũng", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570203" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570203").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570204", Name = "Thái Bình Dương", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570204" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570204").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570205", Name = "Huỳnh Anh Duy", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570205" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570205").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570208", Name = "Quách Đình Hoàng", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570208" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570208").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570209", Name = "DIỆP HƯNG", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570209" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570209").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570210", Name = "Đặng Danh Hữu", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570210" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570210").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570212", Name = "Trần Vinh Khải", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570212" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570212").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570213", Name = "Phạm Minh Khuê", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570213" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570213").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570214", Name = "Nguyễn Văn Kiên", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570214" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570214").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570215", Name = "Nguyễn Châu Kỳ", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570215" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570215").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570216", Name = "Nguyễn Kim Lanh", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570216" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570216").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570217", Name = "Nguyễn Văn Linh", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570217" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570217").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570220", Name = "Nguyễn Văn Luân", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570220" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570220").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570222", Name = "Nguyễn Ngọc Phương", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570222" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570222").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570223", Name = "Nguyễn Thành Phương", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570223" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570223").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570225", Name = "Lưu Hữu Quyết", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570225" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570225").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570233", Name = "Đào Thị Thu Trang", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nữ", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570233" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570233").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570234", Name = "Phạm Thành Trí", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570234" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570234").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570235", Name = "LỤC MINH TUẤN", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570235" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570235").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570236", Name = "Trần Nhật Tuấn", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570236" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570236").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570613", Name = "Nguyễn Anh Huy", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570613" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570613").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570733", Name = "Lâm Trường An", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570733" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570733").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570734", Name = "Nguyễn Hải Vĩnh Cường", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570734" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570734").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570735", Name = "Phạm Hoàng Duy Đức", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570735" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570735").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570737", Name = "Nguyễn Võ Huy Hoàng", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570737" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570737").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570738", Name = "Võ Khánh Huy", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570738" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570738").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570739", Name = "Trần Thị Kim Khánh", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nữ", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570739" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570739").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570740", Name = "Nguyễn Hoàng Minh", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570740" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570740").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570741", Name = "Nguyễn Lê Quang Nhật", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570741" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570741").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570742", Name = "Phan Thanh Nhuần", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570742" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570742").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570743", Name = "Bùi Thanh Phong", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570743" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570743").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570744", Name = "Nguyễn Minh Quân", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570744" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570744").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570745", Name = "Trịnh Bảo Quân", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570745" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570745").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570746", Name = "Võ Nguyên Thành", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570746" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570746").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570747", Name = "Trần Hưng Thuận", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570747" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570747").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570748", Name = "Nguyễn Ngọc Tiến", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570748" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570748").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570749", Name = "Nguyễn Văn Tiền", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570749" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570749").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570750", Name = "Nguyễn Trần Toàn", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570750" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570750").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570751", Name = "Nguyễn Xuân Trãi", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570751" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570751").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570752", Name = "Nguyễn Minh Triết", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570752" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570752").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },
                new Student { Code = "1570753", Name = "Nguyễn Đặng Hoàng Tuấn", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01231570753" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "1570753").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2015/1").Id },

                new Student { Code = "7140020", Name = "Huỳnh Vang", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140020" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140020").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140225", Name = "Nguyễn Văn Dương", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140225" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140225").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140226", Name = "Lê Nguyễn Khánh Duy", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140226" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140226").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140230", Name = "Nguyễn Thanh Hải", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140230" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140230").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140231", Name = "Bùi Đức Hiếu", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140231" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140231").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140235", Name = "Biện Lê Anh Hưng", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140235" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140235").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140237", Name = "Đặng Quốc Huỳnh", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140237" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140237").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140240", Name = "Võ Minh Khải", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140240" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140240").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140258", Name = "Phạm Minh Thiện", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140258" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140258").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140265", Name = "Võ Thái Tuyến", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140265" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140265").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140820", Name = "Âu Mậu Dương", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140820" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140820").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140821", Name = "Đoàn Xuân Duy", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140821" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140821").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140822", Name = "Nguyễn Viết Đáng", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140822" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140822").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140824", Name = "Lê Thanh Hòa", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140824" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140824").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140831", Name = "Trần Cao Nguyên", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140831" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140831").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140832", Name = "Lưu Nguyễn Hoàng Quân", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140832" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140832").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140839", Name = "Nguyễn Khắc Trung", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140839" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140839").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140844", Name = "Trần Nguyên Võ", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140844" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140844").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140845", Name = "Đặng Ngọc Vũ", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140845" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140845").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7140846", Name = "Hoàng Văn Nhật Vũ", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237140846" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7140846").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7141161", Name = "Nguyễn Ngọc Tuyển", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237141161" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7141161").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7141248", Name = "Trần Nam Phong", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237141248" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7141248").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
                new Student { Code = "7141249", Name = "Lê Văn", DateOfBirth = new DateTime(1990, 9, 1), PlaceOfBirth = "Bách Khoa", Gender = "Nam", Address = "268 Lý Thường Kiệt, P.14, Q.10, TPHCM", PhoneNumber = "01237141249" , AccountId = UnitOfWork.Select<Account>().Single(acc => acc.Username == "7141249").Id, StudentClassId = UnitOfWork.Select<StudentClass>().Single(stu => stu.Abbreviation == "MCS2014/1").Id },
            };

            foreach (Student student in students)
            {
                Student dbstudent = UnitOfWork.Select<Student>().FirstOrDefault(model => model.Code == student.Code);
                if (dbstudent == null)
                {
                    UnitOfWork.Insert(student);
                }
                else
                {
                    dbstudent.Name = student.Name;
                    dbstudent.DateOfBirth = student.DateOfBirth;
                    dbstudent.PlaceOfBirth = student.PlaceOfBirth;
                    dbstudent.Gender = student.Gender;
                    dbstudent.Address = student.Address;
                    dbstudent.AccountId = student.AccountId;
                    dbstudent.StudentClassId = student.StudentClassId;
                    UnitOfWork.Update(dbstudent);
                }
            }

            UnitOfWork.Commit();
            #endregion

        }

        private void SeedStudies()
        {
            #region Semester
            Semester[] semesters =
            {
                new Semester { Name = "HK 1/2013-2014", StartDate = new DateTime(2013,8,1), EndDate = new DateTime(2013,12,31), IsCurrentSemester = false },
                new Semester { Name = "HK 2/2013-2014", StartDate = new DateTime(2014,1,1), EndDate = new DateTime(2014,6,1), IsCurrentSemester = false },
                new Semester { Name = "HK 1/2014-2015", StartDate = new DateTime(2014,8,1), EndDate = new DateTime(2014,12,31), IsCurrentSemester = false },
                new Semester { Name = "HK 2/2014-2015", StartDate = new DateTime(2015,1,1), EndDate = new DateTime(2015,6,1), IsCurrentSemester = false },
                new Semester { Name = "HK 1/2015-2016", StartDate = new DateTime(2015,8,1), EndDate = new DateTime(2015,12,31), IsCurrentSemester = false },
                new Semester { Name = "HK 2/2015-2016", StartDate = new DateTime(2016,1,1), EndDate = new DateTime(2016,6,1), IsCurrentSemester = false },
                new Semester { Name = "HK 1/2016-2017", StartDate = new DateTime(2016,8,1), EndDate = new DateTime(2016,12,31), IsCurrentSemester = true },
                new Semester { Name = "HK 2/2016-2017", StartDate = new DateTime(2017,1,1), EndDate = new DateTime(2017,6,1), IsCurrentSemester = false },
            };

            foreach (Semester semester in semesters)
            {
                Semester dbsemester = UnitOfWork.Select<Semester>().FirstOrDefault(model => model.Name == semester.Name);
                if (dbsemester == null)
                {
                    UnitOfWork.Insert(semester);
                }
                else
                {
                    dbsemester.StartDate = semester.StartDate;
                    dbsemester.EndDate = semester.EndDate;
                    dbsemester.IsCurrentSemester = semester.IsCurrentSemester;
                    UnitOfWork.Update(dbsemester);
                }
            }

            UnitOfWork.Commit();
            #endregion

            #region SubjectClass
            SubjectClass[] subjectClasses =
            {
                /* Lập trình nâng cao*/
                new SubjectClass { SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055068").Id, StaffId = UnitOfWork.Select<Staff>().Single(acc => acc.Code == "01995").Id, SemesterId = UnitOfWork.Select<Semester>().Single(acc => acc.Name == "HK 1/2016-2017").Id, RoomOfClassId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "502B4").Id, RoomOfMidtermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "501B4").Id, RoomOfTermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "401C6").Id },
                /* Xử lý ảnh số và Video nâng cao */
                new SubjectClass { SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055009").Id, StaffId = UnitOfWork.Select<Staff>().Single(acc => acc.Code == "01995").Id, SemesterId = UnitOfWork.Select<Semester>().Single(acc => acc.Name == "HK 1/2016-2017").Id, RoomOfClassId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "505B4").Id, RoomOfMidtermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "502B4").Id, RoomOfTermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "402C6").Id },
                /* Phương pháp nghiên cứu khoa học */
                new SubjectClass { SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "505904").Id, StaffId = UnitOfWork.Select<Staff>().Single(acc => acc.Code == "02109").Id, SemesterId = UnitOfWork.Select<Semester>().Single(acc => acc.Name == "HK 1/2016-2017").Id, RoomOfClassId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "501B4").Id, RoomOfMidtermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "503B4").Id, RoomOfTermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "403C6").Id },
                /* Phương pháp nghiên cứu khoa học */
                new SubjectClass { SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "505900").Id, StaffId = UnitOfWork.Select<Staff>().Single(acc => acc.Code == "02109").Id, SemesterId = UnitOfWork.Select<Semester>().Single(acc => acc.Name == "HK 1/2016-2017").Id, RoomOfClassId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "306B1").Id, RoomOfMidtermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "504B4").Id, RoomOfTermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "404C6").Id },
                /* Triết học */
                new SubjectClass { SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "125900").Id, StaffId = UnitOfWork.Select<Staff>().Single(acc => acc.Code == "02109").Id, SemesterId = UnitOfWork.Select<Semester>().Single(acc => acc.Name == "HK 1/2016-2017").Id, RoomOfClassId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "306B4").Id, RoomOfMidtermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "505B4").Id, RoomOfTermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "405C6").Id },
                /* Nhận dạng mẫu và học máy */
                new SubjectClass { SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055069").Id, StaffId = UnitOfWork.Select<Staff>().Single(acc => acc.Code == "00529").Id, SemesterId = UnitOfWork.Select<Semester>().Single(acc => acc.Name == "HK 1/2016-2017").Id, RoomOfClassId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "303B1").Id, RoomOfMidtermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "506B4").Id, RoomOfTermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "406C6").Id },
                /* Đồ họa máy tính nâng cao */
                new SubjectClass { SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055017").Id, StaffId = UnitOfWork.Select<Staff>().Single(acc => acc.Code == "12715").Id, SemesterId = UnitOfWork.Select<Semester>().Single(acc => acc.Name == "HK 1/2016-2017").Id, RoomOfClassId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "305B4").Id, RoomOfMidtermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "401B4").Id, RoomOfTermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "501C6").Id },
                /* Xử lý ngôn ngữ tự nhiên */
                new SubjectClass { SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055016").Id, StaffId = UnitOfWork.Select<Staff>().Single(acc => acc.Code == "00163").Id, SemesterId = UnitOfWork.Select<Semester>().Single(acc => acc.Name == "HK 1/2016-2017").Id, RoomOfClassId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "302B1").Id, RoomOfMidtermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "402B4").Id, RoomOfTermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "502C6").Id },
                /* Hệ hỗ trợ quyết định */
                new SubjectClass { SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055012").Id, StaffId = UnitOfWork.Select<Staff>().Single(acc => acc.Code == "00529").Id, SemesterId = UnitOfWork.Select<Semester>().Single(acc => acc.Name == "HK 1/2016-2017").Id, RoomOfClassId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "301B1").Id, RoomOfMidtermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "403B4").Id, RoomOfTermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "503C6").Id },
                /* Cơ sở tri thức */
                new SubjectClass { SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055006").Id, StaffId = UnitOfWork.Select<Staff>().Single(acc => acc.Code == "01616").Id, SemesterId = UnitOfWork.Select<Semester>().Single(acc => acc.Name == "HK 1/2016-2017").Id, RoomOfClassId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "506C6").Id, RoomOfMidtermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "404B4").Id, RoomOfTermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "504C6").Id },
                /* Lập trình logic và ràng buộc */
                new SubjectClass { SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055008").Id, StaffId = UnitOfWork.Select<Staff>().Single(acc => acc.Code == "00529").Id, SemesterId = UnitOfWork.Select<Semester>().Single(acc => acc.Name == "HK 1/2016-2017").Id, RoomOfClassId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "406B4").Id, RoomOfMidtermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "405B4").Id, RoomOfTermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "505C6").Id },
                /* Giải thuật nâng cao */
                new SubjectClass { SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055001").Id, StaffId = UnitOfWork.Select<Staff>().Single(acc => acc.Code == "13045").Id, SemesterId = UnitOfWork.Select<Semester>().Single(acc => acc.Name == "HK 1/2016-2017").Id, RoomOfClassId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "506B4").Id, RoomOfMidtermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "406B4").Id, RoomOfTermExamId = UnitOfWork.Select<ClassRoom>().Single(acc => acc.Code == "506C6").Id },
            };

            foreach (SubjectClass subjectClass in subjectClasses)
            {
                SubjectClass dbsubjectClass = UnitOfWork.Select<SubjectClass>().FirstOrDefault(model => model.SubjectId == subjectClass.SubjectId && model.SemesterId == subjectClass.SemesterId);
                if (dbsubjectClass == null)
                {
                    UnitOfWork.Insert(subjectClass);
                }
                else
                {
                    dbsubjectClass.RoomOfClassId = subjectClass.RoomOfClassId;
                    dbsubjectClass.RoomOfMidtermExamId = subjectClass.RoomOfMidtermExamId;
                    dbsubjectClass.RoomOfTermExamId = subjectClass.RoomOfTermExamId;
                    UnitOfWork.Update(dbsubjectClass);
                }
            }

            UnitOfWork.Commit();
            #endregion

        }

        private void SeedCurriculums()
        {
            #region CurriculumType
            CurriculumType[] curriculumTypes =
            {
                new CurriculumType { Name = "Bổ sung" },
                new CurriculumType { Name = "Bắt buộc" },
                new CurriculumType { Name = "Tự chọn" },
            };

            foreach (CurriculumType curriculumType in curriculumTypes)
            {
                CurriculumType dbcurriculumType = UnitOfWork.Select<CurriculumType>().FirstOrDefault(model => model.Name == curriculumType.Name);
                if (dbcurriculumType == null)
                {
                    UnitOfWork.Insert(curriculumType);
                }
                else
                {
                    UnitOfWork.Update(dbcurriculumType);
                }
            }

            UnitOfWork.Commit();
            #endregion

            #region Curriculum
            Curriculum[] curriculums =
            {
                new Curriculum { Name = "MCS 2014 By Course", FacultyId = UnitOfWork.Select<Faculty>().Single(acc => acc.Abbreviation == "KH&KTMT").Id },
                new Curriculum { Name = "MCS 2014 By Research", FacultyId = UnitOfWork.Select<Faculty>().Single(acc => acc.Abbreviation == "KH&KTMT").Id },
            };

            foreach (Curriculum curriculum in curriculums)
            {
                Curriculum dbcurriculum = UnitOfWork.Select<Curriculum>().FirstOrDefault(model => model.Name == curriculum.Name);
                if (dbcurriculum == null)
                {
                    UnitOfWork.Insert(curriculum);
                }
                else
                {
                    dbcurriculum.FacultyId = curriculum.FacultyId;

                    UnitOfWork.Update(dbcurriculum);
                }
            }

            UnitOfWork.Commit();
            #endregion

            #region CurriculumDetail
            CurriculumDetail[] curriculumDetails =
            {
                /* Trí tuệ nhân tạo */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "054001").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bổ sung").Id },
                /* Mạng máy tính 1 */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "054002").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bổ sung").Id },
                /* Nguyên lý Ngôn ngữ lập trình */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "054003").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bổ sung").Id },
                /* Phân tích thiết kế giải thuật */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "054004").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bổ sung").Id },

                /* Triết học */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "125900").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bắt buộc").Id },
                /* Phương pháp nghiên cứu khoa học */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "505904").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bắt buộc").Id },
                /* Lập trình nâng cao*/
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055068").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bắt buộc").Id },
                /* Giải thuật nâng cao */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055001").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bắt buộc").Id },
                /* Kiến trúc máy tính nâng cao */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055003").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bắt buộc").Id },
                /* Hệ cơ sở dữ liệu nâng cao */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055002").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bắt buộc").Id },
                /* Luận văn thạc sĩ */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "056001").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bắt buộc").Id },

                /* Xử lý ảnh số và Video nâng cao */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055009").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Nhận dạng mẫu và học máy */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055069").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Cơ sở tri thức */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055006").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Lập trình logic và ràng buộc */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055008").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Hệ phân bố */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055024").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Bảo mật cơ sở dữ liệu */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Course").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055042").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },


                /********************************************************/
                /* Trí tuệ nhân tạo */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "054001").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bổ sung").Id },
                /* Mạng máy tính 1 */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "054002").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bổ sung").Id },
                /* Nguyên lý Ngôn ngữ lập trình */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "054003").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bổ sung").Id },
                /* Phân tích thiết kế giải thuật */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "054004").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bổ sung").Id },

                /* Triết học */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "125900").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bắt buộc").Id },
                /* Phương pháp nghiên cứu khoa học */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "505900").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bắt buộc").Id },
                /* Lập trình nâng cao*/
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055068").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Giải thuật nâng cao */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055001").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Kiến trúc máy tính nâng cao */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055003").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Hệ cơ sở dữ liệu nâng cao */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055002").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Luận văn thạc sĩ */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "056001").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Bắt buộc").Id },

                /* Xử lý ảnh số và Video nâng cao */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055009").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Nhận dạng mẫu và học máy */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055069").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Cơ sở tri thức */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055006").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Lập trình logic và ràng buộc */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055008").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Hệ phân bố */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055024").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
                /* Bảo mật cơ sở dữ liệu */
                new CurriculumDetail { CurriculumId = UnitOfWork.Select<Curriculum>().Single(acc => acc.Name == "MCS 2014 By Research").Id, SubjectId = UnitOfWork.Select<Subject>().Single(acc => acc.Code == "055042").Id, CurriculumTypeId = UnitOfWork.Select<CurriculumType>().Single(acc => acc.Name == "Tự chọn").Id },
            };

            foreach (CurriculumDetail curriculumDetail in curriculumDetails)
            {
                CurriculumDetail dbcurriculumDetail = UnitOfWork.Select<CurriculumDetail>().FirstOrDefault(model => model.SubjectId == curriculumDetail.SubjectId && model.CurriculumId == curriculumDetail.CurriculumId);
                if (dbcurriculumDetail == null)
                {
                    UnitOfWork.Insert(curriculumDetail);
                }
                else
                {
                    dbcurriculumDetail.CurriculumTypeId = curriculumDetail.CurriculumTypeId;
                    UnitOfWork.Update(dbcurriculumDetail);
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

