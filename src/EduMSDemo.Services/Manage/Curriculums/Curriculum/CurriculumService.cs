using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class CurriculumService : BaseService, ICurriculumService
    {
        public CurriculumService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Curriculum, TView>(id);
        }

        public IQueryable<CurriculumView> GetViews()
        {
            return UnitOfWork
                .Select<Curriculum>()
                .To<CurriculumView>()
                .OrderByDescending(o => o.Id);
        }

        public IQueryable<FacultyView> GetFacultyViews()
        {
            return UnitOfWork
                .Select<Faculty>()
                .To<FacultyView>()
                .OrderByDescending(model => model.Id);
        }

        public IQueryable<CourseView> GetCourseViews()
        {
            return UnitOfWork
                .Select<Course>()
                .To<CourseView>()
                .OrderByDescending(model => model.Id);
        }

        public void Create(CurriculumView view)
        {
            Curriculum o = UnitOfWork.To<Curriculum>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(CurriculumView view)
        {
            Curriculum o = UnitOfWork.Get<Curriculum>(view.Id);
            o.Name = view.Name;
            o.FacultyId = view.FacultyId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Curriculum>(id);
            UnitOfWork.Commit();
        }

    }
}
