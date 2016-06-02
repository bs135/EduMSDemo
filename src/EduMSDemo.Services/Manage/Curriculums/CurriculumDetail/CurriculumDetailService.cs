using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class CurriculumDetailService : BaseService, ICurriculumDetailService
    {
        public CurriculumDetailService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<CurriculumDetail, TView>(id);
        }

        public IQueryable<CurriculumDetailView> GetViews(int curriculumId = 0)
        {
            if (curriculumId != 0)
            {
                return UnitOfWork
                    .Select<CurriculumDetail>()
                    .To<CurriculumDetailView>()
                    .Where(o=>o.CurriculumId == curriculumId)
                    .OrderByDescending(o => o.Id);
            }
            return UnitOfWork
                .Select<CurriculumDetail>()
                .To<CurriculumDetailView>()
                .OrderByDescending(o => o.Id);
        }

        public IQueryable<CurriculumView> GetCurriculumViews()
        {
            return UnitOfWork
                .Select<Curriculum>()
                .To<CurriculumView>()
                .OrderByDescending(model => model.Id);
        }

        public IQueryable<SubjectView> GetSubjectViews()
        {
            return UnitOfWork
                .Select<Subject>()
                .To<SubjectView>()
                .OrderByDescending(model => model.Id);
        }

        public IQueryable<CurriculumTypeView> GetCurriculumTypeViews()
        {
            return UnitOfWork
                .Select<CurriculumType>()
                .To<CurriculumTypeView>()
                .OrderByDescending(model => model.Id);
        }

        public void Create(CurriculumDetailView view)
        {
            CurriculumDetail o = UnitOfWork.To<CurriculumDetail>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(CurriculumDetailView view)
        {
            CurriculumDetail o = UnitOfWork.Get<CurriculumDetail>(view.Id);
            o.CurriculumId = view.CurriculumId;
            o.SubjectId = view.SubjectId;
            o.CurriculumTypeId = view.CurriculumTypeId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<CurriculumDetail>(id);
            UnitOfWork.Commit();
        }

    }
}
