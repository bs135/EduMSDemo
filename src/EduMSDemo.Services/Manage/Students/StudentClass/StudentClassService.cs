using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class StudentClassService : BaseService, IStudentClassService
    {
        public StudentClassService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<StudentClass, TView>(id);
        }

        public IQueryable<StudentClassView> GetViews()
        {
            return UnitOfWork
                .Select<StudentClass>()
                .To<StudentClassView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<CourseView> GetCourseViews()
        {
            return UnitOfWork
                .Select<Course>()
                .To<CourseView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<StaffView> GetStaffViews()
        {
            return UnitOfWork
                .Select<Staff>()
                .To<StaffView>()
                .OrderByDescending(o => o.Id);
        }

        public IQueryable<CurriculumView> GetCurriculumViews()
        {
            return UnitOfWork
                .Select<Curriculum>()
                .To<CurriculumView>()
                .OrderByDescending(o => o.Id);
        }

        public void Create(StudentClassView view)
        {
            StudentClass o = UnitOfWork.To<StudentClass>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(StudentClassView view)
        {
            StudentClass o = UnitOfWork.Get<StudentClass>(view.Id);
            o.Abbreviation = view.Abbreviation;
            o.Name = view.Name;
            o.CourseId = view.CourseId;
            o.StaffId = view.StaffId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<StudentClass>(id);
            UnitOfWork.Commit();
        }

    }
}
