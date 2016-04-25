using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface ISemesterService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SemesterView> GetViews();

        void Create(SemesterView view);
        void Edit(SemesterView view);
        void Delete(Int32 id);

    }
}
