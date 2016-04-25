using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class SubjectService : BaseService, ISubjectService
    {
        public SubjectService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Subject, TView>(id);
        }

        public IQueryable<SubjectView> GetViews()
        {
            return UnitOfWork
                .Select<Subject>()
                .To<SubjectView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<DepartmentView> GetDepartmentViews()
        {
            return UnitOfWork
                .Select<Department>()
                .To<DepartmentView>()
                .OrderByDescending(model => model.Id);
        }


        public void Create(SubjectView view)
        {
            Subject o = UnitOfWork.To<Subject>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(SubjectView view)
        {
            Subject o = UnitOfWork.Get<Subject>(view.Id);
            o.Name = view.Name;
            o.Code = view.Code;
            o.Credits = view.Credits;
            o.AcademicCredits = view.AcademicCredits;
            o.DepartmentId = view.DepartmentId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Subject>(id);
            UnitOfWork.Commit();
        }

    }
}
