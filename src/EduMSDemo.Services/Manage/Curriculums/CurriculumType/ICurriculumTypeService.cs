using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface ICurriculumTypeService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CurriculumTypeView> GetViews();
        void Create(CurriculumTypeView view);
        void Edit(CurriculumTypeView view);
        void Delete(Int32 id);

    }
}
