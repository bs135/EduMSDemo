using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class CourseService : BaseService, ICourseService
    {
        public CourseService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Course, TView>(id);
        }

        public IQueryable<CourseView> GetViews()
        {
            return UnitOfWork
                .Select<Course>()
                .To<CourseView>()
                .OrderByDescending(o => o.Id);
        }

        public IQueryable<FacultyView> GetFacultyViews()
        {
            return UnitOfWork
                .Select<Faculty>()
                .To<FacultyView>()
                .OrderByDescending(model => model.Id);
        }

        public void Create(CourseView view)
        {
            Course o = UnitOfWork.To<Course>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(CourseView view)
        {
            Course o = UnitOfWork.Get<Course>(view.Id);
            o.Code = view.Code;
            o.Name = view.Name;
            o.StartDate = view.StartDate;
            o.EndDate = view.EndDate;
            o.FacultyId = view.FacultyId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Course>(id);
            UnitOfWork.Commit();
        }

    }
}
