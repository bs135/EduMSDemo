using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface ICurriculumDetailService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CurriculumDetailView> GetViews(int curriculumId = 0);

        IQueryable<CurriculumView> GetCurriculumViews();
        IQueryable<SubjectView> GetSubjectViews();
        IQueryable<CurriculumTypeView> GetCurriculumTypeViews();

        void Create(CurriculumDetailView view);
        void Edit(CurriculumDetailView view);
        void Delete(Int32 id);

    }
}
