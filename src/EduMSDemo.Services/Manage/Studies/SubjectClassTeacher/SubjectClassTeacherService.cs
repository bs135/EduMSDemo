using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class SubjectClassTeacherService : BaseService, ISubjectClassTeacherService
    {
        public SubjectClassTeacherService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SubjectClassTeacher, TView>(id);
        }

        public IQueryable<SubjectClassTeacherView> GetViews()
        {
            return UnitOfWork
                .Select<SubjectClassTeacher>()
                .To<SubjectClassTeacherView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<SubjectClassView> GetSubjectClassViews()
        {
            return UnitOfWork
                .Select<SubjectClass>()
                .To<SubjectClassView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<StaffView> GetStaffViews()
        {
            return UnitOfWork
                .Select<Staff>()
                .To<StaffView>()
                .OrderByDescending(o => o.Id);
        }

        public void Create(SubjectClassTeacherView view)
        {
            SubjectClassTeacher o = UnitOfWork.To<SubjectClassTeacher>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(SubjectClassTeacherView view)
        {
            SubjectClassTeacher o = UnitOfWork.Get<SubjectClassTeacher>(view.Id);
            o.Accountability = view.Accountability;
            o.StaffId = view.StaffId;
            o.SubjectClassId = view.SubjectClassId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SubjectClassTeacher>(id);
            UnitOfWork.Commit();
        }

    }
}
